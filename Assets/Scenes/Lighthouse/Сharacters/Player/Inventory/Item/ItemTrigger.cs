using UnityEngine;

namespace Assets.Scenes.Lighthouse.Сharacters.Player.Inventory
{
    public class ItemTrigger : TriggerZone
    {
        public bool posibilityToRaise = false;

        private Item item;

        public void Update()
        {
            if (posibilityToRaise && Input.GetKey(KeyCode.E))
            {
                global::Inventory.AddItem(item);
                posibilityToRaise = false;
            }
        }
    }
}