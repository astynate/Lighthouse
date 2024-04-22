using Assets.Scenes.Lighthouse;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : InventoryObserver
{
    private Cell[] _inventoryCells;

    private Cell[] _boxCells;

    private Cell[] _specialCells;

    private UnityEngine.Canvas _canvas;

    private GameObject _preview;

    private Image _image;

    private TextMeshProUGUI _name;

    private TextMeshProUGUI _description;

    private GameObject _box;

    private bool _isAvailable = true;

    private void Awake()
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

        for (int i = 0; i < _specialCells.Length; i++)
        {
            _specialCells[i].Items = Inventory.SpecialItems;
            _specialCells[i].Index = i;
        }

        for (int i = 0; i < _boxCells.Length; i++)
        {
            _boxCells[i].Index = i;
        }

        _preview = GameObject.FindWithTag("Preview");
        _image = GameObject.FindWithTag("ItemImage").GetComponent<Image>();
        _name = GameObject.FindWithTag("ItemName").GetComponent<TextMeshProUGUI>();
        _description = GameObject.FindWithTag("ItemDescription").GetComponent<TextMeshProUGUI>();

        _preview.SetActive(false);
        _box = GameObject.FindWithTag("BoxItems");
    }

    private void SelectCellByItem(Item item)
    {
        Cell[][] cells = { _inventoryCells, _boxCells, _specialCells };

        foreach (Cell[] cellArray in cells)
        {
            foreach (Cell cell in cellArray)
            {
                cell.UnSelect();

                if (cell.Items[cell.Index] != null && cell.Items[cell.Index].Name == item.Name)
                {
                    cell.Select();
                }
            }
        }
    }

    private void SetPreview(Item item)
    {
        if (item == null)
        {
            DisablePreview();
            return;
        }

        _image.sprite = item.Preview;
        _name.text = item.Name;
        _description.text = item.Description;
        _preview.SetActive(true);

        SelectCellByItem(item);
    }

    private void DisablePreview()
    {
        _preview.SetActive(false);
    }

    private void SetPreviewFromItems(params Item[][] itemList)
    {
        foreach (Item[] items in itemList)
        {
            Item item = items.FirstOrDefault(x => x != null); SetPreview(item);

            if (item != null)
            {
                return;
            }
        }
    }

    private IEnumerator SetAsAvailable(float delay)
    {
        if (Inventory.Items[Inventory.CurrentItemIndex] is not null)
        {
            SetPreview(Inventory.Items[Inventory.CurrentItemIndex]);
        }
        else
        {
            SetPreviewFromItems(Inventory.SpecialItems, _boxCells[0].Items, Inventory.Items);
        }

        yield return new WaitForSecondsRealtime(delay);
        _isAvailable = true;
    }

    public void Open()
    {
        if (_isAvailable == true)
        {
            _isAvailable = false;
            _canvas.enabled = !_canvas.enabled;

            StartCoroutine(SetAsAvailable(0.5f));
            Time.timeScale = _canvas.enabled ? 0f : 1f;
        }

        _box.SetActive(false);
    }

    public void Open(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            _boxCells[i].Items = items;
            _boxCells[i].Redraw(ref items[_boxCells[i].Index]);
        }

        Open(); _box.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Open();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Collider2D[] objectsUnderMouse = Physics2D.OverlapPointAll(mousePosition);

            foreach (Collider2D collider in objectsUnderMouse)
            {
                GameObject gameObject = collider.gameObject;
                ExecuteEvents.Execute<IDropHandler>(gameObject, null, (x, y) => x.OnDrop(null));
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Collider2D[] objectsUnderMouse = Physics2D.OverlapPointAll(mousePosition);

            foreach (Collider2D collider in objectsUnderMouse)
            {
                GameObject gameObject = collider.gameObject;
                Cell item = gameObject.GetComponent<Cell>();

                if (item != null)
                {
                    SetPreview(item.Items[item.Index]);
                }
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

        for (int i = 0; i < _boxCells.Length; i++)
        {
            if (_boxCells[i].Items.Length == 8)
            {
                _boxCells[i].Redraw(ref _boxCells[i].Items[i]);
            }
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