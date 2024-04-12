using Assets.Scenes.Lighthouse;
using UnityEngine;
using UnityEngine.UI;



public class InteractionController : MonoBehaviour
{
    private float _playerRadius = 1.5f;

    private LayerMask _itemLayerMask;

    private Collider[] _hitColliders;

    private float currentTime = 0.0f;

    private float toWait = 0.3f;

    public GameObject ScrollElementPrefab;


    private void Awake()
    {
        _itemLayerMask = LayerMask.GetMask("InventoryItem");
    }

    public void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if (currentTime > toWait) 
        {        
            HandleInteractions();
            currentTime = 0.0f;
        }
    }

    private void HandleInteractions()
    {
        _hitColliders = Physics.OverlapSphere(transform.position, _playerRadius, _itemLayerMask);

        if (_hitColliders.Length == 1 && Input.GetKey(KeyCode.E))
        {
            Configuration.InteractionCanvas.enabled = true;
            Inventory.AddItem(_hitColliders[0].GetComponent<Item>());

            _hitColliders[0].transform.position = new Vector3(200f, 200f, 200f);
        }
        else if (_hitColliders.Length > 1)
        {
            Configuration.ScrollViewCanvas.enabled = true;

            DeleteAllTagObjects();

            foreach (Collider item in _hitColliders)
            {
                NewItemToScrollBar(item.GetComponent<Item>());
            }
        }
        else {
            Configuration.ScrollViewCanvas.enabled = false;
        }
    }



    private void NewItemToScrollBar(Item item)
    {
        GameObject instance = Instantiate(ScrollElementPrefab);

        instance.transform.SetParent(Configuration.ScrollView.transform);

        instance.tag = "PanelTag";

        Transform child1 = instance.transform.GetChild(0);
        Transform child2 = instance.transform.GetChild(1);

        Image childImage = child1.GetComponent<Image>();
        childImage.sprite = item.Image;

        Button childButton = child2.GetComponent<Button>();
        Debug.Log(childButton.GetType());

        childButton.onClick.AddListener(M);
    }


    private void M()
    {
        Debug.Log("кнопка нажата");
    }


    void DeleteAllTagObjects()
    {
        GameObject[] itemInScrollBar = GameObject.FindGameObjectsWithTag("PanelTag");
        foreach (GameObject item in itemInScrollBar)
        {
            Destroy(item);
        }
    }

}