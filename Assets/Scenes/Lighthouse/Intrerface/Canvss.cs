using UnityEngine;

public class Canvss : MonoBehaviour
{
    Canvas canvas;
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.enabled = false;
        }

    }

    public void ChangeVisibity()
    {
        if (canvas.enabled) canvas.enabled = false;
        else canvas.enabled = false;
    }
}
