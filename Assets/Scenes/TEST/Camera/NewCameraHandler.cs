using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.IO.LowLevel.Unsafe;

public class NewCameraHandler : MonoBehaviour
{
    public Transform RotationPoint; 
    public Transform Player;
    public float offsetZ = -5;
    public float offsetY = 1.3f;
    public float sensitivity = 3; 

    private Vector3 offset;
    private float X, Y;

    void Start()
    {
        offset  = new Vector3(0,offsetY,offsetZ);
        transform.position = new Vector3(RotationPoint.position.x,Player.position.y,RotationPoint.position.z)  + offset;
    }

    void Update()
    {
        X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(0, X, 0);
        transform.position = transform.localRotation * offset + new Vector3(RotationPoint.position.x,Player.position.y,RotationPoint.position.z);
    }
}