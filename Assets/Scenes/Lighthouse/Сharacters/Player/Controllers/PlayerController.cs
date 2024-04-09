using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)] public float rotationSpeed = 20.0f;

    [Range(0, 20)] public float speed = 8.0f;

    [Range(0, 7)] public float boundaryRadius = 7f;

    public bool isHide = false;

    private int _healthPoints = 100;

    private int _fearPoints = 0;
    
    private Animator _animator;

    private Rigidbody _rigidbody;

    private Inventory _playerInventory;

    private MeshRenderer[] _meshRenderer;



    private Vector3 lastInteraxtionDir;
   
    private void Awake()
    {
        _playerInventory = gameObject.AddComponent<Inventory>();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponentsInChildren<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        if (isHide == true) 
        {
            _animator.SetFloat("Speed", 0);
            return;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (movement != Vector3.zero)
        {
            _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion
                .LookRotation(Vector3.ClampMagnitude(movement * Time.fixedDeltaTime, 1)), rotationSpeed));

            lastInteraxtionDir = movement;
        }

        //HandleInteractions();

        Vector3 newPosition = _rigidbody.position + Vector3
            .ClampMagnitude(movement * Time.fixedDeltaTime * speed, 1);

        if (newPosition.magnitude < boundaryRadius)
        {
            _rigidbody.MovePosition(newPosition);
        }
        else
        {
            _rigidbody.MovePosition(newPosition.normalized * boundaryRadius);
        }

        _animator.SetFloat("Speed", Vector3.ClampMagnitude(movement, 1).magnitude);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0f, 0f, 0f), boundaryRadius);
    }

    public int GetHealthPoints => _healthPoints;
    public int GetFearPoints => _fearPoints;

    public void TakeDamage(int damage)
    {
        if (damage <= _healthPoints)
        {
            _healthPoints -= damage;
        }

        if (_healthPoints <= 0)
        {
            Application.Quit();
        }
    }

    public Inventory GetInventory
    {
        get => _playerInventory;
    }

    public void Show()
    {
        Array.ForEach(_meshRenderer, 
            (mesh) => mesh.enabled = true);
    }

    public void Hide()
    {
        Array.ForEach(_meshRenderer,
            (mesh) => mesh.enabled = false);
    }

    //private void HandleInteractions()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, _playerRadius, itemLayerMask);
    //    Debug.Log(hitColliders.Length > 0);
    //    if (hitColliders.Length > 0)
    //    {
    //        InteractionCanvas.enabled = true;
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            Debug.Log(hitColliders.Length);
    //            foreach (var collider in hitColliders)
    //            {
    //                InventoryItem item = collider.GetComponentInParent<InventoryItem>();
    //                if (item != null) // Проверка на n
    //                {
    //                    Debug.Log(item);
    //                }
    //                else
    //                {
    //                    Debug.Log("InventoryItem компонент не найден на объекте: " + collider.name);
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        InteractionCanvas.enabled = false;
    //        Debug.Log("обьект потерян");
    //    }




    //    //if (Physics.SphereCast(transform.position, _playerRadius, lastInteraxtionDir, out RaycastHit RayOnItem, _playerRaycastistance, itemLayerMask))
    //    //{
    //    //    RayOnItem.transform.TryGetComponent(out InventoryItem item);
    //    //    InteractionCanvas.enabled = true;
    //    //    Debug.Log("обьект найден");
    //    //    if (Input.GetKeyDown(KeyCode.E))
    //    //    {
    //    //        _playerInventory.PutNewObject(item);
    //    //    }
    //    //}
    //    //else if (Physics.SphereCast(transform.position, _playerRadius, lastInteraxtionDir, out RaycastHit RayOnCloset, _playerRaycastistance, ClosetLayerMask))
    //    //{
    //    //    RayOnCloset.transform.TryGetComponent(out Closet closet);
    //    //    InteractionCanvas.enabled = true;
    //    //    Debug.Log("шкаф найден");
    //    //    if (Input.GetKeyDown(KeyCode.E))
    //    //    {

    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    InteractionCanvas.enabled = false;
    //    //    Debug.Log("обьект потерян");
    //    //}

    //}
}