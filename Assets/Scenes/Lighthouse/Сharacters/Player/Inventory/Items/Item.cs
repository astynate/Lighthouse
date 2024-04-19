using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public string Name;

    [SerializeField] public string Description;

    [SerializeField] public Sprite Image;

    [SerializeField] public bool inInvenory = false;

    public abstract void Interact();
    public abstract void OnSelect();
}