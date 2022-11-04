using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MoveHandler))]

public class Selectable : MonoBehaviour
{
    [SerializeField] private CharacterAnimationHandler _characterAnimation;

    private MoveHandler _moveHandler;
    private Coroutine _coroutine;

    public void Selected()
    {
        _moveHandler.enabled = true;
        _characterAnimation.PlaySelectedAnimation();
    }

    public void OffMove()
    {
        _moveHandler.enabled = false;
        _characterAnimation.Deselect();
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
