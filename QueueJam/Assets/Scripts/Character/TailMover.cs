using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class TailMover : MonoBehaviour
{
    private Transform _transform;
    private Coroutine _coroutine;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 targetPosition,float moveSpeed)
    {
        _coroutine = StartCoroutine(Moving(targetPosition, moveSpeed));
    }

    private IEnumerator Moving(Vector3 targetPosition, float moveSpeed)
    {
        float waitTime = 0.01f;
        var wait = new WaitForSeconds(waitTime);

        while (_transform.position != targetPosition)
        {
            _transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed);
            yield return wait;
        }
    }
}
