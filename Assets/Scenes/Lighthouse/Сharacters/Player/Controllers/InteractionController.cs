using Assets.Scenes.Lighthouse;
using System;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private float _playerRadius = 1.5f;

    private LayerMask _itemLayerMask;

    private Collider[] _hitColliders;

    private float _currentTime = 0.0f;

    private float _toWait = 0.1f;

    private KeyCode[] _inventoryKeycodes = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

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

            Inventory.AddItem(ref item);
            _hitColliders[0].transform.position = new Vector3(200f, 200f, 200f);
        }
    }
}