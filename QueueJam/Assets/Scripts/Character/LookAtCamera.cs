using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Update()
    {
        transform.LookAt(_camera);
    }
}
