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

    public void TryMove(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        Ray backRay = new Ray(transform.position, -direction);
        RaycastHit hit;
        RaycastHit backHit;
        Physics.Raycast(ray, out hit, _rayDistance);
        Physics.Raycast(backRay, out backHit, _rayDistance);

        if (hit.collider == null && backHit.collider.gameObject.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
        {
            Vector3 destination = _transform.position + direction;

            if (_isMoving == false)
            {
                _isMoving = true;

                //if (_tail != null)
                //{
                //    if (_tail.TryGetComponent<TailMover>(out TailMover tailMover))
                //    {
                //        tailMover.Move(_transform.position);
                //    }
                //}

                for (int i = 1; i < _tails.Count; i++)
                {
                    _tails[i].TryGetComponent<TailMover>(out TailMover tailMover);
                    tailMover.Move(_tails[i-1].transform.position);
                }

                _coroutine = StartCoroutine(Moving(destination));

            }
        }

        _selectable.OffMove();
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
