using Assets.Scenes.Lighthouse.Ñharacters.NPC;
using System.Collections;
using System.Linq;
using UnityEngine;

public class GhostController : NPC
{
    private Collider _triggerZone;

    private Collider _damageZone;

    private PlayerController _player;

    private bool _isPlayerInDamageZone;

    private readonly int _damage = 2;


    private void Start()
    {
        GetPlayerObject();

        Collider[] colliders = GetComponentsInChildren<Collider>();

        _player = _playerObject.GetComponent<PlayerController>();

        _triggerZone = colliders.FirstOrDefault(collider => collider
            .gameObject.tag == "Trigger Zone");

        _damageZone = colliders.FirstOrDefault(collider => collider
            .gameObject.tag == "Damage Zone");
    }

    private IEnumerator MakeDamage()
    {
        while (_isPlayerInDamageZone == true)
        {
            _player.TakeDamage(_damage);
            yield return new WaitForSeconds(1f);
        }
    }

    private void FixedUpdate()
    {
        if (_triggerZone.bounds.Contains(_playerObject.transform.position))
        {
            FollowCharacter();
        }

        if (_damageZone.bounds.Contains(_playerObject.transform.position) && _isPlayerInDamageZone == false)
        {
            _isPlayerInDamageZone = true;
            StartCoroutine(MakeDamage());
        }

        if (_damageZone.bounds.Contains(_playerObject.transform.position) == false && _isPlayerInDamageZone == true) 
        {
            _isPlayerInDamageZone = false;
            StopCoroutine(MakeDamage());
        }

    }
}
