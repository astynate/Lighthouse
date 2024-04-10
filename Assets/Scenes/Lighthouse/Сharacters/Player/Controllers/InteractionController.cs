using Assets.Scenes.Lighthouse;
using System;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private float _playerRadius = 1.5f;

    private LayerMask _itemLayerMask;

    private Collider[] _hitColliders;

    private float currentTime = 0.0f;

    private float toWait = 0.5f;

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

        Debug.Log(_hitColliders.Length);

        if (_hitColliders.Length == 1 && Input.GetKey(KeyCode.E))
        {
            Configuration.InteractionCanvas.enabled = true;
            Inventory.AddItem(_hitColliders[0].GetComponent<Item>());

            _hitColliders[0].transform.position = new Vector3(200f, 200f, 200f);
        }
    }
}