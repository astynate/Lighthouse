using Assets.Scenes.Lighthouse.—haracters.NPC;
using System.Collections;
using System.Linq;
using UnityEngine;

public class GhostController : NPC
{
    private Collider _triggerZone;

    private Collider _damageZone;

    private bool _isPlayerInDamageZone;

    private readonly int _damage = 2;


    private void Start()
    {
        GetPlayer();

        Collider[] colliders = GetComponentsInChildren<Collider>();

        _triggerZone = colliders.FirstOrDefault(collider => collider
            .gameObject.tag == "Trigger Zone");

        _damageZone = colliders.FirstOrDefault(collider => collider
            .gameObject.tag == "Damage Zone");
    }

    private IEnumerator MakeDamage()
    {
        while (_isPlayerInDamageZone == true && _player.isHide == false)
        {
            _player.TakeDamage(_damage);
            yield return new WaitForSeconds(1f);
        }
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(_playerObject.transform.position, _triggerZone.bounds.center);
        bool isInside = distance <= _triggerZone.bounds.extents.magnitude;

        //Debug.Log(isInside);
        Walk(isInside);

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
