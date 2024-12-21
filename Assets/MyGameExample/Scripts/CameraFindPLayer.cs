using Cinemachine;
using UnityEngine;

public class CameraFindPLayer : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    public void Initialize(CameraTarget cameraTarget)
    {
        _camera.Follow = cameraTarget.transform;
    }
}
