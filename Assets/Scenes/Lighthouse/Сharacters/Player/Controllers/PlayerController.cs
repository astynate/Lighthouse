using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20)] public float rotationSpeed = 20.0f;

    [Range(0, 20)] public float speed = 8.0f;

    [Range(0, 7)] public float boundaryRadius = 7f;

    private int _healthPoints = 100;

    private int _fearPoints = 0;
    
    private Animator _animator;

    private Rigidbody _rigidbody;

    private Inventory _playerInventory;

    //private Vector3 lastInteraxtionDir;

    //private float _liftingRadius = 1.5f;

    public void Awake()
    {
        _playerInventory = new Inventory();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    HandleInteractions();
    //}

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (movement != Vector3.zero)
        {
            _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion
                .LookRotation(Vector3.ClampMagnitude(movement * Time.fixedDeltaTime, 1)), rotationSpeed));

            //lastInteraxtionDir = movement;
        }

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



    //private void HandleInteractions()
    //{
    //    if (Physics.SphereCast(transform.position, _liftingRadius, lastInteraxtionDir, out RaycastHit raycastHit, _liftingRadius))
    //    {
    //        if (raycastHit.transform.TryGetComponent(out InventoryItem item) && Input.GetKey(KeyCode.E))
    //        {
    //            _playerInventory.PutNewObject(item);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("-");
    //    }
    //}


    public Inventory GetInventory
    {
        get => _playerInventory;
    }

    public override string ToString()
    {
        return $"{_healthPoints} {speed} {rotationSpeed}";
    }
}
