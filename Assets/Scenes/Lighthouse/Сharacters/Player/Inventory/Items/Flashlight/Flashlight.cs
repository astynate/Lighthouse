using Assets.Scenes.Lighthouse;
using UnityEngine;

public class Flashlight : Item
{
    private Light _light;

    private Rigidbody _collider;

    void Start()
    {
        _collider.GetComponent<Rigidbody>();
        _light = GetComponentInChildren<Light>();
        _light.enabled = false;
        Debug.Log(_collider);
    }

    private void FixedUpdate()
    {
        //_collider.isTrigger = inInvenory;
    }

    public override void Interact()
    {
        _light.enabled = !_light.enabled;
    }

    public override void OnSelect()
    {
        //transform.position = Configuration.RightHand.transform.position;
    }
}