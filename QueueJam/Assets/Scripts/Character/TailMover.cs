using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class TailMover : MonoBehaviour
{
    //[SerializeField] private GameObject _tail;

    private float _moveSpeed = 0.05f;
    private Transform _transform;
    private Coroutine _coroutine;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 targetPosition)
    {
        _coroutine = StartCoroutine(Moving(targetPosition));

        //if (_tail != null)
        //{
        //    _tail.TryGetComponent<TailMover>(out TailMover tailMover);
        //    tailMover.Move(transform.position);
        //}
    }

    private IEnumerator Moving(Vector3 targetPosition)
    {
        float waitTime = 0.01f;
        var wait = new WaitForSeconds(waitTime);

        while (_transform.position != targetPosition)
        {
            _transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed);
            yield return wait;
        }
    }
}
