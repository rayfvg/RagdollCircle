using Cinemachine;
using UnityEngine;

public class CameraFindPLayer : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Initialize(CameraTarget cameraTarget)
    {
        _camera.Follow = cameraTarget.transform;
    }
}
