using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public Canvas canvas;

    public virtual void OnTriggerEnter(Collider other)
    {
        canvas.enabled = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
    }
}