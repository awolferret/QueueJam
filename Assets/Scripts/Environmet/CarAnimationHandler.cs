using System.Collections;
using UnityEngine;

public class CarAnimationHandler : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Vector3 _startScale;
    private Coroutine _coroutine;
    private float _sizeChangeAmount = 0.02f;

    public void PlayEffect(int index)
    {
        _coroutine = StartCoroutine(HitEffect(index));
    }

    private void Start()
    {
        _startScale = transform.localScale;
    }

    private IEnumerator HitEffect(int index)
    {
        float wait = 0.05f;
        var waitType = new WaitForSeconds(wait);

        for (int i = 0; i < index; i++)
        {
            //_transform.localScale = _startScale + new Vector3(_sizeChangeAmount, _sizeChangeAmount, _sizeChangeAmount);
            _transform.localScale = _transform.localScale + new Vector3(_sizeChangeAmount, _sizeChangeAmount, _sizeChangeAmount);
            yield return waitType;
            //_transform.localScale = _startScale;
            //yield return waitType;
        }
    }
}
