using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;

    private float _minimalDistance = 1f;
    private bool _isDrawing = false;
    private Coroutine _coroutine;
    private Camera _mainCamera;
    private PlayerInputs _playerInput;
    private RaycastHit _hit;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector2 _delta;

    public void StartDrawLine()
    {
        _isDrawing = true;
        _startPosition = GetMousePosition();
    }

    public void StopDrawLine()
    {
        _arrow.transform.localScale = new Vector3(0.6f, 0, 0);
        _isDrawing = false;
    }

    private void Update()
    {
        if (_isDrawing == true)
        {
            _endPosition = GetMousePosition();
            Vector2 startPoint = new Vector2(_startPosition.x, _startPosition.z);
            Vector2 endPoint = new Vector2(_endPosition.x, _endPosition.z);
            _delta = endPoint - startPoint;

            if (transform.forward == new Vector3(0, 0, 1) || transform.forward == new Vector3(0, 0, -1))
            {
                _arrow.transform.localScale = new Vector3(0.6f, -endPoint.y / 5, 0);
            }
            else
            {
                _arrow.transform.localScale = new Vector3(0.6f, -endPoint.x / 5, 0);
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Physics.Raycast(CastRay(), out _hit);
        Vector3 position = new Vector3(_hit.point.x, 0, _hit.point.z);
        return position;
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
