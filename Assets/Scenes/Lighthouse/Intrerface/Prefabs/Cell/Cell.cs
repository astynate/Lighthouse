using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Inventory;

public class Cell : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] public Image SelectedImage;

    [SerializeField] public Image Image;

    private Item _item;

    private RectTransform _rectTransform;

    private Vector3 _cellOriginalTransform;

    public Item[] Items;

    public int Index;

    private UnityEngine.Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInParent<UnityEngine.Canvas>();
        _canvas.sortingOrder = 5;
        SelectedImage.enabled = false;
        _rectTransform = Image.GetComponent<RectTransform>();
    }

    private void SetImage()
    {
        if (_item != null && _item.Image != null)
        {
            Image.GetComponent<RectTransform>().anchoredPosition = SelectedImage
                .GetComponent<RectTransform>().anchoredPosition;

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