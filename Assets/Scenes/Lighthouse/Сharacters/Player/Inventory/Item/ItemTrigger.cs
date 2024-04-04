using UnityEngine;

namespace Assets.Scenes.Lighthouse.Сharacters.Player.Inventory.Item
{
    public class ItemTrigger: TriggerZone
    {
        public bool posibilityToRaise = false;

        public new void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            posibilityToRaise = true;

            if (other.gameObject.CompareTag("Player"))
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                InventoryItem item = gameObject.transform.parent.GetComponent<InventoryItem>();
                item.PlayerInZone(player);
            }
        }

        public new void OnTriggerExit(Collider other)
        {
            base.OnTriggerEnter(other);
            posibilityToRaise = false;
        }
    }
}
