using Assets.Scenes.Lighthouse;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public virtual void OnTriggerEnter(Collider other)
    {
        Configuration.InteractionCanvas.enabled = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        Configuration.InteractionCanvas.enabled = false;
    }
}