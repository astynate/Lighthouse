using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] public string Name;

    [SerializeField] public string Description;

    [SerializeField] public Sprite Image;

    [SerializeField] public Sprite Preview;

    [SerializeField] public bool inInvenory = false;

    /// <summary>
    /// ���������� ��� ������� �� ������� R
    /// ���� ������ ������� � ������ ���� ���
    /// </summary>
    public abstract void Interact();

    /// <summary>
    /// ���������� ������ ���� ����
    /// ������ �������
    /// </summary>
    public virtual void Selected() { }

    /// <summary>
    /// ���������� ���� ��� ��� ���������
    /// �������
    /// </summary>
    public virtual void OnSelect() { }

    /// <summary>
    /// ���������� ���� ��� ��� ������
    /// ��������� � �������
    /// </summary>
    public virtual void UnSelect() { }
}