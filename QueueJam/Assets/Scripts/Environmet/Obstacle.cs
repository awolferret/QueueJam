using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Vector3 _startScale;
    private Vector3 _startPosition;
    private Coroutine _coroutine;
    private float _sizeChangeAmount = 0.05f;

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
        float wait = 0.01f;
        var waitType = new WaitForSeconds(wait);
        _transform.localScale = _startScale + new Vector3(_sizeChangeAmount, _sizeChangeAmount, _sizeChangeAmount);
        _transform.position = _startPosition + (direction * _sizeChangeAmount);
        yield return waitType;
        _transform.localScale = _startScale;
        _transform.position = _startPosition;
    }
}
