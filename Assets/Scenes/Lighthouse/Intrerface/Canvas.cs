using UnityEngine;

public class Canvas : MonoBehaviour
{
    UnityEngine.Canvas canvas;

    void Awake()
    {
        canvas = GetComponent<UnityEngine.Canvas>();

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