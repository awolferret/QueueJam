using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MoveHandler : MonoBehaviour
{
    private float _moveSpeed = 0.05f;
    private float _rayDistance = 1f;
    private Transform _transform;
    private bool _isMoving = false;
    private Coroutine _coroutine;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        SwipeDetection.SwipeInput += TryMove;
    }

    private void OnDisable()
    {
        SwipeDetection.SwipeInput -= TryMove;
    }

    private void TryMove(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, _rayDistance);

        if (hit.collider == null)
        {
            Vector3 destination = _transform.position + direction;

            if (_isMoving == false)
            {
                _isMoving = true;
                _coroutine = StartCoroutine(Moving(destination));
            }
        }
    }

    private IEnumerator Moving(Vector3 destination)
    {
        float waitTime = 0.01f;
        var wait = new WaitForSeconds(waitTime);

        while (_transform.position != destination)
        {
            _transform.position = Vector3.MoveTowards(transform.position, destination, _moveSpeed);
            yield return wait;
        }

        _isMoving = false;
    }
}
