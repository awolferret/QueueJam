using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveHandler))]

public class Selectable : MonoBehaviour
{
    private MoveHandler _moveHandler;
    private Coroutine _coroutine;

    public void Selected()
    {
        _moveHandler.enabled = true;
        _coroutine = StartCoroutine(OffMoveCoroutine());
    }

    public void OffMove()
    {
        _moveHandler.enabled = false;
    }

    private void Start()
    {
        _moveHandler = GetComponent<MoveHandler>();
    }

    private IEnumerator OffMoveCoroutine()
    {
        float waitTime = 0.25f;
        var waitType = new WaitForSeconds(waitTime);
        yield return waitType;
        OffMove();
    }
}
