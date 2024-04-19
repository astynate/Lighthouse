using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(0f, playerTransform.position.y, 0f) + offset;
    }
}
