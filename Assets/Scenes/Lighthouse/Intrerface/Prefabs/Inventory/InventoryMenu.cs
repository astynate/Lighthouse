using Assets.Scenes.Lighthouse;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryMenu : InventoryObserver
{
    private Cell[] _inventoryCells;

    private Cell[] _boxCells;

    private Cell[] _specialCells;

    private UnityEngine.Canvas _canvas;

    private bool _isAvailable = true;

    private void Start()
    {
        _canvas = GetComponentInChildren<UnityEngine.Canvas>();
        _canvas.enabled = false;

        Cell[] cells = _canvas.GetComponentsInChildren<Cell>();

        _inventoryCells = cells.Where(x => x.tag == "Inventory").ToArray();
        _boxCells = cells.Where(x => x.tag == "Box").ToArray();
        _specialCells = cells.Where(x => x.tag == "Special").ToArray();

        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            _inventoryCells[i].Items = Inventory.Items;
            _inventoryCells[i].Index = i;
        }

        for (int i = 0; i < _boxCells.Length; i++)
        {
            _boxCells[i].Items = Inventory.BoxItems;
            _boxCells[i].Index = i;
        }

        for (int i = 0; i < _specialCells.Length; i++)
        {
            _specialCells[i].Items = Inventory.SpecialItems;
            _specialCells[i].Index = i;
        }
    }

    private IEnumerator SetAsAvailable(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        _isAvailable = true;
    }

    private void Update()
    {
        if (_isAvailable == true && Input.GetKey(KeyCode.F))
        {
            _isAvailable = false;
            _canvas.enabled = !_canvas.enabled;

            StartCoroutine(SetAsAvailable(0.5f));
            Time.timeScale = _canvas.enabled ? 0f : 1f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Collider2D[] objectsUnderMouse = Physics2D.OverlapPointAll(mousePosition);
            foreach (Collider2D collider in objectsUnderMouse)
            {
                GameObject go = collider.gameObject;
                ExecuteEvents.Execute<IDropHandler>(go, null, (x, y) => x.OnDrop(null));
            }
        }
    }

    protected override void HandleItemsChanged()
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            _inventoryCells[i].Redraw(ref Inventory.Items[i]);
        }

        for (int i = 0; i < _specialCells.Length; i++)
        {
            _specialCells[i].Redraw(ref Inventory.SpecialItems[i]);
        }
    }

    protected override void HandleSelect()
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (i == Inventory.CurrentItemIndex)
            {
                _inventoryCells[i].Select();
            }
            else
            {
                _inventoryCells[i].UnSelect();
            }
        }
    }
}