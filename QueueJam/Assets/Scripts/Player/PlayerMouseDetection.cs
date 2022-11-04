using UnityEngine;

public class PlayerMouseDetection : MonoBehaviour
{
    private PlayerInputs _playerInput;
    private Camera _mainCamera;
    private RaycastHit _hit;

    public Selectable TrySelect()
    {
        if (Physics.Raycast(CastRay(), out _hit))
        {
            if (_hit.collider.gameObject.TryGetComponent<Selectable>(out Selectable selectable))
            {
                return selectable;
            }

            else
            {
                return null;
            }
        }

        else
        {
            return null;
        }
    }

    public Vector3 GetButtonUpPosition()
    {
        Physics.Raycast(CastRay(), out _hit);
        return _hit.point;
    }

    public Vector3 GetMousePosition()
    { 
        return _hit.point;
    }

    private Ray CastRay()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_playerInput.Player.MouseDetection.ReadValue<Vector2>());
        return ray;
    }

    private void Awake()
    {
        _playerInput = new PlayerInputs();
        _mainCamera = Camera.main;
        _playerInput.Enable();
    }
}
