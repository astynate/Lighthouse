using Assets.Scenes.Lighthouse;
using UnityEngine;

public abstract class TriggerZone : MonoBehaviour
{
    bool isActive = false;

    public virtual void OnTriggerEnter(Collider other)
    {
        Configuration.InteractionCanvas.enabled = true;
        isActive = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        Configuration.InteractionCanvas.enabled = false;
        isActive = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            Interact();
        }
    }

    public abstract void Interact();
}