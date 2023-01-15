using UnityEngine;

[RequireComponent(typeof(MoveHandler))]

public class Selectable : MonoBehaviour
{
    [SerializeField] private CharacterAnimationHandler _characterAnimation;
    [SerializeField] private LineDrawer _lineDrawer;

    private MoveHandler _moveHandler;
    private Coroutine _coroutine;

    public void Selected()
    {
        _moveHandler.enabled = true;
        _characterAnimation.PlaySelectedAnimation();
        //_lineDrawer.StartDrawLine();
    }

    public void OffMove()
    {
        _moveHandler.enabled = false;
        _characterAnimation.Deselect();
        //_lineDrawer.StopDrawLine();
    }

    private void Start()
    {
        _moveHandler = GetComponent<MoveHandler>();
    }
}
