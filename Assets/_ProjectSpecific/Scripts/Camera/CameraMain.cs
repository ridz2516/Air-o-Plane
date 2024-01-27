
using Cinemachine;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _CinemachineCamera;
    public CinemachineVirtualCamera GameplayVirtualCam => _CinemachineCamera;
}
