using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Vector3 _startScale;
    private Vector3 _startPosition;
    private Coroutine _coroutine;

    public void PlayEffect(Vector3 direction)
    {
        _coroutine = StartCoroutine(HitEffect(direction));
    }

    private void Start()
    {
        _startScale = transform.localScale;
        _startPosition = transform.position;
    }

    private IEnumerator HitEffect(Vector3 direction)
    {
        _transform.localScale = _startScale + new Vector3(0.05f, 0.05f, 0.05f);
        _transform.position = _startPosition + (direction * 0.05f);
        yield return new WaitForSeconds(0.1f);
        _transform.localScale = _startScale;
        _transform.position = _startPosition;
    }
}
