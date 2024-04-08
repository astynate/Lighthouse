using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private InventoryItem[] inventory = new InventoryItem[3];
    private int _cellForNewObject = 0;
    private Canvas inventoryCanvas;

    private void Awake()
    {
        inventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
    }

    public void PutNewObject(InventoryItem item)
    {
        inventory[_cellForNewObject] = item;

        Image[] images = inventoryCanvas.GetComponentsInChildren<Image>();
        Debug.Log($"количество картинок {images.Length}"); 
        if (_cellForNewObject < images.Length)
        {
            Debug.Log($"должна сработать смена картинки");
            Debug.Log(item.GetSprite.name);
            images[_cellForNewObject].sprite = item.GetSprite;
            _cellForNewObject++;
            Debug.Log(this);
        }
        else
        {
            Debug.Log("No more space in the inventory!");
        }
    }
   
    public override string ToString()
    {
        return $"количество {_cellForNewObject} занятых ячеек";
    }

    public void ChangeSelectedItem()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {

        }
    }
}
