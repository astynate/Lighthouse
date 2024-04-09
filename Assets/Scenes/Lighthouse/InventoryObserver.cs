using UnityEngine;

namespace Assets.Scenes.Lighthouse
{
    public abstract class InventoryObserver : MonoBehaviour
    {
        private void OnEnable()
        {
            Inventory.onItemsChanged += HandleItemsChanged;
        }

        private void OnDisable()
        {
            Inventory.onItemsChanged -= HandleItemsChanged;
        }

        abstract protected void HandleItemsChanged();
    }
}