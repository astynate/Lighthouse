using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}
