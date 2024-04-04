using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _picture;
    private Canvas canvasInventory;
    private PlayerController _player;

    private void Awake()
    {
        canvasInventory = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
    }


    public void PlayerInZone(PlayerController player)
    {
         Debug.Log("вошли в триггер");
        _player = player;
    }

    public Sprite GetSprite
    {
        get => _picture;
    }


    private void Update()
    {
        Debug.Log(posibilityToRaise);
        if (posibilityToRaise && Input.GetKey(KeyCode.E))
        {
            GameObject parentWithInventoryItem = transform.gameObject;

            if (parentWithInventoryItem != null)
            {
                Debug.Log("Нашли родительский объект с InventoryItem");
                InventoryItem item = GetComponent<InventoryItem>();
                _player.GetInventory.PutNewObject(canvasInventory, item);
                Destroy(parentWithInventoryItem);
            }
            canvas.enabled = false;
        }
    }


}


//public void OnTriggerExit(Collider other)
//{
//    if (other.gameObject.CompareTag("Player"))
//    {
//        Debug.Log("вышли из триггера");
//        canvasE.enabled = false;
//        _player = null;
//        _posibilityToPick = false;
//    }
//}

