using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tails;
    [SerializeField] private Selectable _selectable;

    private float _moveSpeed = 0.05f;
    private float _rayDistance = 1f;
    private Transform _transform;
    private bool _isMoving = false;
    private Coroutine _coroutine;
    private Vector3 _currentDirection;

    public List<GameObject> Tails => _tails;

    public void MoveTo(Vector3 direction)
    {
        _coroutine = StartCoroutine(Moving(direction));
    }

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
        float one = 1;
        float half = 2; 
        Ray ray = new Ray(transform.position, direction);
        Ray backRay = new Ray(transform.position, -direction);
        RaycastHit hit;
        RaycastHit backHit;
        Physics.Raycast(ray, out hit);
        Physics.Raycast(backRay, out backHit, _rayDistance);
        Vector3 destination = hit.point - (direction / half);

        if (_isMoving == false)
        {
            if (_tails.Count > 0)
            {
                if (backHit.collider.gameObject == _tails[0].gameObject)
                {
                    _isMoving = true;
                    _coroutine = StartCoroutine(Moving(destination));

                    for (int i = 0; i < _tails.Count; i++)
                    {
                        _tails[i].TryGetComponent<TailMover>(out TailMover tailMover);
                        tailMover.Move(destination - (direction * (i + one)),_moveSpeed);
                    }
                }
                else
                {
                    _selectable.OffMove();
                }
            }
            else
            {
                _isMoving = true;
                _coroutine = StartCoroutine(Moving(destination));
            }
        }
        else 
        {
            _selectable.OffMove();
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

        _selectable.OffMove();
        _isMoving = false;
    }
}
