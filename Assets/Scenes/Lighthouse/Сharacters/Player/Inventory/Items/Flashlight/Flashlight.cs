using Assets.Scenes.Lighthouse;
using UnityEngine;

public class Flashlight : Item
{
    private Light _light;

    public Collider _collider;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _light.enabled = false;
    }

    private void FixedUpdate()
    {
        _collider.enabled = !inInvenory;
    }

    public override void Interact()
    {
        _light.enabled = !_light.enabled;
    }

    public override void OnSelect()
    {
        transform.rotation = Configuration.PlayerObject.transform.rotation;
        transform.position = Configuration.RightHand.transform.position;
    }
}