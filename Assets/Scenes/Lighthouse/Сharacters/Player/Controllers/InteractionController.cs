using UnityEngine;
using UnityEngine.UIElements;

public class InteractionController : MonoBehaviour
{
    private PlayerController player;
    private float _playerRadius = .5f;
    //private float _playerRaycastistance = 3f;
    private LayerMask itemLayerMask;
    //private LayerMask ClosetLayerMask;
    private Canvas InteractionCanvas;
    private Canvas ItemsCanvas;
    private Collider[] hitColliders;
    private GameObject [] panels;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        itemLayerMask = LayerMask.GetMask("InventoryItem");
        //ClosetLayerMask = LayerMask.GetMask("Closets");
        InteractionCanvas = GameObject.FindGameObjectWithTag("CanvasE").GetComponent<Canvas>();
        ItemsCanvas = GameObject.FindGameObjectWithTag("ItemsCanvas").GetComponent<Canvas>();
        panels = GameObject.FindGameObjectsWithTag("Panel");
    }

    public void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _playerRadius, itemLayerMask);
        Debug.Log(hitColliders.Length > 0);
        if (hitColliders.Length == 1)
        {
            //ItemsCanvas.enabled = false;
            InteractionCanvas.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log(hitColliders.Length);
                Debug.Log(hitColliders[0].GetComponentInParent<InventoryItem>());
            }
        }
        else if (hitColliders.Length > 1)
        {
            InteractionCanvas.enabled = false;
            //ItemsCanvas.enabled = true;
            for (int i = 0; i < hitColliders.Length && i < 3; ++i)
            {
                if (hitColliders[i] != null) // Проверка на n
                {
                    Debug.Log(hitColliders[i].GetComponentInParent<InventoryItem>());
                }
                else
                {
                    Debug.Log("InventoryItem компонент не найден на объекте: " + hitColliders[i].name);
                }
            }
        }
        else
        {
            //ItemsCanvas.enabled = false;
            InteractionCanvas.enabled = false;
            Debug.Log("обьект потерян");
        }

    }
}
