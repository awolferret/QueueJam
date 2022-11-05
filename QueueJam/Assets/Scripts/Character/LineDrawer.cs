using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;

    private bool _isDrawing = false;
    private Coroutine _coroutine;
    private Camera _mainCamera;
    private PlayerInputs _playerInput;
    private RaycastHit _hit;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    public void StartDrawLine()
    {
        _isDrawing = true;
        _startPosition = GetMousePosition();
    }

    public void StopDrawLine()
    {
        float width = 0.6f;
        _arrow.transform.localScale = new Vector3(width, 0, 0);
        _isDrawing = false;
    }

    private void Update()
    {
        float one = 1;
        float width = 0.6f;
        float divider = 5;

        if (_isDrawing == true)
        {
            _endPosition = GetMousePosition();
            Vector2 endPoint = new Vector2(_endPosition.x, _endPosition.z);
            Vector2 startPoint = new Vector2(_startPosition.x, _startPosition.z);
            Vector2 delta = Vector2.zero;
            delta = endPoint - startPoint;
            //float axis = Mathf.Atan2(endPoint.x, endPoint.y) * Mathf.Rad2Deg;
            float axis = Vector2.Angle(transform.position, endPoint);
            Debug.Log(axis);
            //Debug.Log(delta.magnitude);

            if (transform.forward == new Vector3(0, 0, one))
            {
                _arrow.transform.localScale = new Vector3(width, delta.magnitude/divider /*-endPoint.y / divider*/, 0);
            }
            else if (transform.forward == new Vector3(0, 0, -one))
            {
                _arrow.transform.localScale = new Vector3(width, delta.magnitude/divider /* endPoint.y / divider*/, 0);
            }
            else if (transform.forward == new Vector3(one, 0, 0))
            {
                _arrow.transform.localScale = new Vector3(width, delta.magnitude / divider/*-endPoint.x / divider*/, 0);
            }
            else if (transform.forward == new Vector3(-one, 0, 0))
            {
                _arrow.transform.localScale = new Vector3(width, delta.magnitude / divider/*endPoint.x / divider*/, 0);
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
