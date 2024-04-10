using Assets.Scenes.Lighthouse;

public class QuikAccessInventory : InventoryObserver
{
    private Cell[] _cells = new Cell[3];

    void Awake()
    {
        _cells = GetComponentsInChildren<Cell>();
    }

    protected override void HandleItemsChanged()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Redraw(ref Inventory.Items[i]);
        }
    }
}