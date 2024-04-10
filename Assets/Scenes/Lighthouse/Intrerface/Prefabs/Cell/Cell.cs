using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] public Image SelectedImage;

    [SerializeField] public Image Image;

    private Item _item;

    private void Awake()
    {
        SelectedImage.enabled = false;
    }

    private void SetImage()
    {
        if (_item != null && _item.Image != null)
        {
            Image.sprite = _item.Image;
            Image.enabled = true;
        }
        else
        {
            Image.sprite = null;
            Image.enabled = false;
        }
    }

    public void Redraw(ref Item item)
    {
        _item = item; SetImage();
    }

    public void Select() 
        => SelectedImage.enabled = true;
    
    public void UnSelect() 
        => SelectedImage.enabled = false;
}