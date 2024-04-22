using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public string Name;

    [SerializeField] public string Description;

    [SerializeField] public Sprite Image;

    [SerializeField] public Sprite Preview;

    [SerializeField] public bool inInvenory = false;

    /// <summary>
    /// Вызывается при нажатии на конопку R
    /// Если объект выделен и только один раз
    /// </summary>
    public abstract void Interact();

    /// <summary>
    /// Вызывается каждый кадр если
    /// объект выделен
    /// </summary>
    public virtual void Selected() { }

    /// <summary>
    /// Вызывается один раз при выделении
    /// объекта
    /// </summary>
    public virtual void OnSelect() { }

    /// <summary>
    /// Вызывается один раз при снятии
    /// выделения с объекта
    /// </summary>
    public virtual void UnSelect() { }
}