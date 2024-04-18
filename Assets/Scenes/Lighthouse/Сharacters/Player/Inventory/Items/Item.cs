using UnityEngine;

public class Item : MonoBehaviour, IInteract
{
    [SerializeField] public string Name;

    [SerializeField] public Sprite Image;

    [SerializeField] public bool inInvenory = false;

    public void Interact()
    {
        Debug.Log("!");
    }
}