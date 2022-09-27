using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Transform))]

public class Selectable : MonoBehaviour
{
    private Renderer _renderer;
    private Transform _transform;
    private float _moveSpeed = 0.05f;
    private Coroutine _coroutine;
    private bool _isMoving = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
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

    public void Selected()
    {
        _renderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        _renderer.material.color = Color.grey;
    }

    private void TryMove(Vector3 direction)
    {
        Vector3 destination = _transform.position + direction;

        if (_isMoving == false)
        {
            _isMoving = true;
            _coroutine = StartCoroutine(Moving(destination));
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
