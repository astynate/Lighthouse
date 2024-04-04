using UnityEngine;
using Cinemachine;

public class CameraPathSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private CinemachineSmoothPath _smoothPath;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = _smoothPath; //пока по тегу игрока трекаем
    }
}