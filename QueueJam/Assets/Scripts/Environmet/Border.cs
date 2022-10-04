using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Border : MonoBehaviour
{
    [SerializeField] private List<Transform> _exitPoints;

    private Coroutine _coroutine;
    private MoveHandler _handler;
    private Transform _firstPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
        {
            _firstPoint = moveHandler.gameObject.transform;
            _exitPoints[0] = _firstPoint;
            _handler = moveHandler;
            _coroutine = StartCoroutine(MoveToExit());
        }
    }

    private IEnumerator MoveToExit()
    {
        float delay = 0.8f;
        float speed = 0.8f;
        var wait = new WaitForSeconds(delay);
        var tailWait = new WaitForSeconds((delay / _handler.Tails.Count));

        for (int i = 0; i < _exitPoints.Count; i++)
        {
            _handler.TryGetComponent<TailMover>(out TailMover tailMoverFirst);
            tailMoverFirst.Move(_exitPoints[i].transform.position, speed);

            if (_handler.Tails.Count > 0)
            {
                foreach (var tail in _handler.Tails)
                {
                    yield return tailWait;
                    tail.gameObject.GetComponent<BoxCollider>().enabled = false;
                    tail.TryGetComponent<TailMover>(out TailMover tailMover);
                    ExitSequence(tail, i, speed);
                }
            }

            yield return wait;
        }
    }

    private void ExitSequence(GameObject gameObject,int index,float speed)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOMove(_exitPoints[index].position, speed));
    }
}
