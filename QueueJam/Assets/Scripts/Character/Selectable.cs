using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(MoveHandler))]

public class Selectable : MonoBehaviour
{
    private Renderer _renderer;
    private MoveHandler _moveHandler;
    private Coroutine _coroutine;
    private Color _startColor;

    public void Selected()
    {
        _moveHandler.enabled = true;
        _coroutine = StartCoroutine(OffMoveCoroutine());
    }

    public void Deselect()
    {
        _renderer.material.color = _startColor;
    }

    public void OffMove()
    {
        _moveHandler.enabled = false;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _moveHandler = GetComponent<MoveHandler>();
        _startColor = _renderer.material.color;
    }

    private IEnumerator OffMoveCoroutine()
    {
        float waitTime = 1f;
        var waitType = new WaitForSeconds(waitTime);
        yield return waitType;
        OffMove();
    }
}
