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

    private MeshRenderer[] _meshRenderer;

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
}