using UnityEngine;

public class NewBehaviourScript : TriggerZone
{
    private Animator _animator;

    private Collider _internalCollider;

    private GameObject _player;

    private bool _isPlayerInCollider = false;

    private bool _isOpen = false;

    private bool _isAvailable = true;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _internalCollider = GetComponentInChildren<Collider>();
        _player = GameObject.FindWithTag("Player");
    }

    private void SetAvailable()
    {
        PlayerController playerModel = _player.GetComponent<PlayerController>();

        playerModel.isHide = _isOpen && _internalCollider.bounds
            .Contains(_player.transform.position);

        if (playerModel.isHide)
        {
            playerModel.Hide();
        }

        else
        {
            playerModel.Show();
        }

        _isAvailable = true;
    }

    private void FixedUpdate()
    {
        if (_isPlayerInCollider == true && Input.GetKey(KeyCode.E) == true && _isAvailable == true)
        {
            _isOpen = !_isOpen;
            _isAvailable = false;

            if (_isOpen)
            {
                _animator.ResetTrigger("Close");
                _animator.SetTrigger("Open");
            }
            else
            {
                _animator.ResetTrigger("Open");
                _animator.SetTrigger("Close");
            }

            Invoke("SetAvailable", 0.5f);
        }
    }

    //public override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //    _isPlayerInCollider = other.gameObject.tag == "Player";
    //}

    //public override void OnTriggerExit(Collider other)
    //{
    //    _isAvailable = true;
    //    _isPlayerInCollider = false;
    //}
}
