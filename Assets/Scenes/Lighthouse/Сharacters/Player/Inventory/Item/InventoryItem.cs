using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;


    public Sprite GetSprite
    {
        get => _picture;
    }


}


