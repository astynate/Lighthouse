using UnityEngine;

namespace Assets.Scenes.Lighthouse.Сharacters.Player.Inventory.Item
{
    public class ItemTrigger: TriggerZone
    {
        public bool posibilityToRaise = false;
        private PlayerController player;
        private InventoryItem item;

        //public new void OnTriggerEnter(Collider other)
        //{
        //    base.OnTriggerEnter(other);

        //    posibilityToRaise = true;

        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        player = other.gameObject.GetComponent<PlayerController>();
        //        item = gameObject.GetComponentInParent<InventoryItem>();
        //    }
        //}

        //public new void OnTriggerExit(Collider other)
        //{
        //    base.OnTriggerEnter(other);
        //    posibilityToRaise = false;
        //}

        //public void Update()
        //{
        //    if (posibilityToRaise && Input.GetKey(KeyCode.E))
        //    {
        //        player.GetInventory.PutNewObject(item);
        //        Destroy(gameObject.transform.parent.gameObject);
        //    }
        //}
    }
}
