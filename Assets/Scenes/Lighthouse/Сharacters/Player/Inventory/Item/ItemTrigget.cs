using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public Canvas canvasE;
    public Canvas canvasInventory;
    private PlayerController _player;
    private bool _posibilityToPick = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("вошли в триггер");
            canvasE.enabled = true;
            _player = other.gameObject.GetComponent<PlayerController>();
            _posibilityToPick = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("вышли из триггера");
            canvasE.enabled = false;
            _player = null;
            _posibilityToPick = false;
        }
    }

    void Update()
    {
        if (_posibilityToPick && Input.GetKey(KeyCode.E))
        {
            GameObject parentWithInventoryItem = transform.parent.gameObject;
           
            if (parentWithInventoryItem != null)
            {
                Debug.Log("Нашли родительский объект с InventoryItem");
                InventoryItem item = parentWithInventoryItem.GetComponent<InventoryItem>();
                _player.GetInventory.PutNewObject(canvasInventory, item);
                Destroy(parentWithInventoryItem);
            }
            else
            {
                Debug.Log("Не нашли родительский объект с InventoryItem");
            }
            canvasE.enabled = false;
        }
    }
}
