using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Item _item;

    private Image _image;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
    }

    private void SetImage()
    {
        if (_item != null && _item.Image != null)
        {
            _image.sprite = _item.Image;
            _image.enabled = true;
        }
        else
        {
            _image.sprite = null;
            _image.enabled = false;
        }
    }

    public void Redraw(ref Item item)
    {
        _item = item; SetImage();
    }
}