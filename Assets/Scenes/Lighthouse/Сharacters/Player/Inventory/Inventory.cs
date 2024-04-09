using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Item[] Items { get; private set; } = new Item[3];
    public static Item[] SpecialItems { get; private set; } = new Item[8];
    public static Item[] BoxItems { get; private set; } = new Item[8];

    public delegate void OnItemsChanged();

    public static event OnItemsChanged onItemsChanged;

    private static bool AddItemToArray(Item[] items, ref Item item)
    {
        int index = Array.FindIndex(Items, x => x == null);

        if (index == -1)
        {
            return false;
        }

        Items[index] = item;
        onItemsChanged?.Invoke();

        return true;
    }

    public static bool AddItem(Item item)
        => AddItemToArray(Items, ref item);
}