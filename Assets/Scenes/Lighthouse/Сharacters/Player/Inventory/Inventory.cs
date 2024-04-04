using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private InventoryItem[] inventory = new InventoryItem[3];
    private int _cellForNewObject = 0;
    private Canvas inventoryCanvas;


    public void PutNewObject(Canvas canvas, InventoryItem item)
    {
        inventoryCanvas = canvas;
        inventory[_cellForNewObject] = item;

        Image[] images = inventoryCanvas.GetComponentsInChildren<Image>();
        Debug.Log($"количество картинок {images.Length}"); 
        if (_cellForNewObject < images.Length)
        {
            Debug.Log($"долэна сработать смена картинки");
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
        return $"{_cellForNewObject} зан€тых количестов €чеек";
    }
}
