using UnityEngine;

namespace Assets.Scenes.Lighthouse
{
    public abstract class InventoryObserver : MonoBehaviour
    {
        private void OnEnable()
        {
            Inventory.onItemsChanged += HandleItemsChanged;
            Inventory.onSelect += HandleSelect;

            Inventory.SetCurrentItemIndex(0);
        }

        private void OnDisable()
        {
            Inventory.onItemsChanged -= HandleItemsChanged;
            Inventory.onSelect -= HandleSelect;
        }

        abstract protected void HandleSelect();
        abstract protected void HandleItemsChanged();
    }
}