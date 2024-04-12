using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Item[] Items { get; private set; } = new Item[3];
    public static Item[] SpecialItems { get; private set; } = new Item[8];
    public static Item[] BoxItems { get; private set; } = new Item[8];

    public delegate void OnItemsChanged();

    public static event OnItemsChanged onItemsChanged;

    private static bool AddItemToArray(ref Item item)
    {
        int index = Array.FindIndex(Items, x => x == null);

        if (item.inInvenory || index == -1)
        {
            return false;
        }

        item.inInvenory = true;
        Items[index] = item;

        onItemsChanged?.Invoke();
        return true;
    }

    public static bool AddItem(Item item)
        => AddItemToArray(ref item);
}