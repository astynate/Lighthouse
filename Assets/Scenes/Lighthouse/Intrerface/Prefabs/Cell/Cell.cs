using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Inventory;

public class Cell : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] public Image SelectedImage;

    [SerializeField] public Image image;

    private Item _item;

    private RectTransform _rectTransform;

    public Item[] Items;

    public int Index;

    private void Start()
    {
        SelectedImage.enabled = false;
        _rectTransform = image.GetComponent<RectTransform>();
    }

    private void SetImage()
    {
        if (_item != null && _item.Image != null)
        {
            _rectTransform.position = SelectedImage
                .GetComponent<RectTransform>().position;

            image.sprite = _item.Image;
            image.enabled = true;
        }
        else
        {
            image.sprite = null;
            image.enabled = false;
        }
    }

    public void Redraw(ref Item item)
    {
        _item = item; SetImage();
    }

    public void Select()
    {
        if (_item != null)
        {
            _item.OnSelect();
        }

        SelectedImage.enabled = true;
    }
    
    public void UnSelect()
    {
        if (_item != null)
        {
            _item.UnSelect();
        }

        SelectedImage.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Configuration.InventoryCanvas != null)
        {
            Configuration.DragableCell = this;

            _rectTransform.anchoredPosition += eventData.delta /
                Configuration.InventoryCanvas.scaleFactor;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Configuration.DragableCell == null || Configuration.DragableCell._item == _item)
        {
            return;
        }

        Item buff = Items[Index];
        Items[Index] = Configuration.DragableCell.Items[Configuration.DragableCell.Index];

        Configuration.DragableCell.Items[Configuration.DragableCell.Index] = buff;
        Configuration.DragableCell = null;

        InvokeChangeEvent();
    }
}