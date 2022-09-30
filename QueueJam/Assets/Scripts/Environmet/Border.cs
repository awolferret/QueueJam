using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private List<GameObject> _exitPoints;

    private Coroutine _coroutine;
    private MoveHandler _handler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
        {
            _handler = moveHandler;
            _coroutine = StartCoroutine(MoveToExit());
        }
    }

    private IEnumerator MoveToExit()
    {
        float delay = 0.3f;
        float speed = 0.5f;
        var waitType = new WaitForSeconds(delay);

        yield return waitType;

        for (int i = 0; i < _exitPoints.Count; i++)
        {
            _handler.TryGetComponent<TailMover>(out TailMover tailMoverFirst);
            tailMoverFirst.Move(_exitPoints[i].transform.position, speed);

            if (_handler.Tails.Count > 0)
            {
                for (int j = 0; j < _handler.Tails.Count; j++)
                {
                    yield return waitType;
                    _handler.Tails[j].TryGetComponent<TailMover>(out TailMover tailMover);
                    tailMover.Move(_exitPoints[i].transform.position, speed);
                }
            }
            else
            {

                yield return waitType;
            }

        }
    }
}
