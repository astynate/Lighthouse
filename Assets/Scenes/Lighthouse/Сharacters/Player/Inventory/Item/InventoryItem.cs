using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;
    private bool posibilityToRaise = false; 

    public Sprite GetSprite
    {
        get => _picture;
    }

    public bool PosibilityToRaise
    {
        get => posibilityToRaise;
        set => posibilityToRaise = value;
    }

    public override string ToString()
    {
        return $"{_name}";
    }
}