using Assets.Scenes.Lighthouse;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    private float _playerRadius = 1.5f;

    private LayerMask _itemLayerMask;

    private Collider[] _hitColliders;

    private float _currentTime = 0.0f;

    private float _toWait = 0.1f;

    private KeyCode[] _inventoryKeycodes = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    private int _countItems = 0;

    public GameObject ScrollElementPrefab;

    private void Awake()
    {
        _itemLayerMask = LayerMask.GetMask("InventoryItem");
    }

    public void FixedUpdate()
    {
        _currentTime += Time.fixedDeltaTime;

        if (_currentTime > _toWait)
        {        
            HandleInteractions();
            _currentTime = 0.0f;
        }
    }

    private void Update()
    {
        foreach (KeyCode keycode in _inventoryKeycodes)
        {
            if (Input.GetKey(keycode))
            {
                Inventory.SetCurrentItemIndex(Array.IndexOf(_inventoryKeycodes, keycode));
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Inventory.RemoveElement();
        }
    }

    private void HandleInteractions()
    {
        _hitColliders = Physics.OverlapSphere(transform.position, _playerRadius, _itemLayerMask);

        if (_hitColliders.Length == 1 && Input.GetKey(KeyCode.E))
        {
            Configuration.InteractionCanvas.enabled = true;

            Item item = _hitColliders[0].GetComponent<Item>();
            Inventory.AddItem(_hitColliders[0], item);
        }
        else if (_hitColliders.Length > 0 && _hitColliders.Length != _countItems)
        {
            Configuration.ScrollViewCanvas.enabled = true;

            DeleteAllTagObjects();

            foreach (Collider hitCollider in _hitColliders)
            {
                Item refItem = hitCollider.GetComponent<Item>();
                NewItemToScrollBar(hitCollider, refItem);
            }

            _countItems = _hitColliders.Length;
        }
        else if (_hitColliders.Length == 0)
        {
            Configuration.ScrollViewCanvas.enabled = false;
        }
    }

    private void NewItemToScrollBar(Collider hitCollider, Item item)
    {
        GameObject instance = Instantiate(ScrollElementPrefab);

        instance.transform.SetParent(Configuration.ScrollView.transform);
        instance.tag = "PanelTag";

        Transform child1 = instance.transform.GetChild(0);
        Transform child2 = instance.transform.GetChild(1);

        Image childImage = child1.GetComponent<Image>();
        childImage.sprite = item.Image;
        Button childButton = child2.GetComponent<Button>();
        
        childButton.onClick.AddListener(() => AddItemFromScrollbar(hitCollider, item));
    }

    private void AddItemFromScrollbar(Collider hitCollider, Item item)
    {
        Inventory.AddItem(hitCollider, item);
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