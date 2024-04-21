using Assets.Scenes.Lighthouse;
using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Item[] Items { get; private set; } = new Item[3];
    public static Item[] SpecialItems { get; private set; } = new Item[4];
    public static int CurrentItemIndex { get; private set; } = 0;

    public delegate void OnItemsChanged();

    public static event OnItemsChanged onItemsChanged;

    public static event OnItemsChanged onSelect;

    public static void RemoveElement()
    {
        if (Items[CurrentItemIndex] != null)
        {
            Items[CurrentItemIndex].gameObject.transform.position = Configuration.PlayerObject.transform.position;
            Items[CurrentItemIndex].GetComponent<Rigidbody>().isKinematic = false;
            Items[CurrentItemIndex].inInvenory = false;
            Items[CurrentItemIndex] = null;
            onItemsChanged?.Invoke();
        }
    }

    public static void SetCurrentItemIndex(int index)
    {
        if (index >= 0 && index < 3)
        {
            CurrentItemIndex = index;
            onSelect?.Invoke();
        }
    }

    private static bool AddItemToArray(ref Item item)
    {
        int index = Array.FindIndex(Items, x => x == null);

        if (item.inInvenory || index == -1)
        {
            return false;
        }

        item.inInvenory = true;
        item.GetComponent<Rigidbody>().isKinematic = true;

        Items[index] = item;

        onItemsChanged?.Invoke();
        return true;
    }

    public static void AddItem(Collider collider, Item item)
    {
        if (AddItemToArray(ref item))
        {
            collider.transform.position = new Vector3(200f, 200f, 200f);
        }
    }

    internal static void UseCurrentItem()
    {
        if (Items[CurrentItemIndex] != null)
        {
            Items[CurrentItemIndex].Interact();
        }
    }

    internal static void OnSelect()
    {
        if (Items[CurrentItemIndex] != null)
        {
            Items[CurrentItemIndex].Selected();
            InvokeChangeEvent();
        }
    }

    public static void InvokeChangeEvent() 
        => onItemsChanged?.Invoke();
}