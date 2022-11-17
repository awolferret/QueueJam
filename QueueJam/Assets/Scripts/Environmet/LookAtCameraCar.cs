using UnityEngine;

public class LookAtCameraCar : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private Transform _camera;

    public void SetCamera(GameObject camera)
    {
        _camera = camera.transform;
    }

    private void Update()
    {
        _canvas.transform.LookAt(_camera);
    }
}
