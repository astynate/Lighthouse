using Assets.Scenes.Lighthouse;
using System.Collections;
using System.Linq;
using UnityEngine;

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
    }

    protected override void HandleItemsChanged()
    {
        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            _inventoryCells[i].Redraw(ref Inventory.Items[i]);
        }
    }
}