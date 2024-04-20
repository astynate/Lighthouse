using Assets.Scenes.Lighthouse;

public class QuikAccessInventory : InventoryObserver
{
    private Cell[] _cells = new Cell[3];

    void Awake()
    {
        _cells = GetComponentsInChildren<Cell>();

        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Items = Inventory.Items;
            _cells[i].Index = i;
        }
    }

    protected override void HandleItemsChanged()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Redraw(ref Inventory.Items[i]);
        }
    }

    protected override void HandleSelect()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            if (i == Inventory.CurrentItemIndex)
            {
                _cells[i].Select();
            } 
            else
            {
                _cells[i].UnSelect();
            }
        }
    }
}