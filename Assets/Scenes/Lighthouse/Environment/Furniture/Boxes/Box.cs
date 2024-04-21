using Assets.Scenes.Lighthouse;
using System.Linq;
using UnityEngine;

public class Box : TriggerZone
{
    public Item[] items = new Item[8];

    public override void Interact()
    {
        if (items.Length == 8)
        {
            Configuration.InventoryMenuInstance.Open(items);
        }
        else
        {
            Configuration.InventoryMenuInstance.Open();
        }
    }
}