using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    [Range(1, 5)] public int depth = 2;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x / depth, playerTransform.position.y, 
            playerTransform.position.z / depth) + offset;
    }
}