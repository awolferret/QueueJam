using UnityEngine;

public class LookAtCamer : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Update()
    {
        transform.LookAt(_camera);
    }
}
