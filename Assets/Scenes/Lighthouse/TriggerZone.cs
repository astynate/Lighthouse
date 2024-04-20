using Assets.Scenes.Lighthouse;
using UnityEngine;

public abstract class TriggerZone : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        Configuration.InteractionCanvas.enabled = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        Configuration.InteractionCanvas.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public abstract void Interact();
}