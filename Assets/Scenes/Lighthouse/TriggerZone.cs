using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public UnityEngine.Canvas canvas;

    public virtual void OnTriggerEnter(Collider other)
    {
        canvas.enabled = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
    }
}