using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseDetection : MonoBehaviour
{
    private PlayerInputs _playerInput;
    private Camera _mainCamera;
    private Selectable _currentSelectable;
    private RaycastHit _hit;

    public RaycastHit Hit => _hit;

    public Selectable TrySelect()
    {
        Ray ray = _mainCamera.ScreenPointToRay(_playerInput.Player.MouseDetection.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out _hit))
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

    public Vector3 GetMousePosition()
    { 
        return _hit.point;
    }

    private void Awake()
    {
        _playerInput = new PlayerInputs();
        _playerInput.Enable();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }
}
