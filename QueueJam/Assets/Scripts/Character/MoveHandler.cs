using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Transform))]

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tails;
    [SerializeField] private Selectable _selectable;
    [SerializeField] private CharacterAnimationHandler _animationHandler;
    [SerializeField] private CharacterParticlesHandler _particlesHandler;
    [SerializeField] private EmotionHandler _emotionHandler;

    private float _moveTime = 0.5f;
    private bool _isMoving = false;
    private Coroutine _coroutine;
    private Vector3 _currentDirection;

    public List<GameObject> Tails => _tails;

    public void CantMoveEffect()
    {
        _animationHandler.PlayCantMoveAnimation();
        _emotionHandler.ShowAngryEmotion();
    }

    private void OnEnable()
    {
        SwipeDetection.SwipeInput += TryMove;
    }

    private void OnDisable()
    {
        SwipeDetection.SwipeInput -= TryMove;
    }

    private void TryMove(Vector3 direction)
    {
        float one = 1;
        float half = 2;
        float minimalDistance = 1f;
        Quaternion quaternion;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 lookDirection = hit.point - transform.position;
        Vector3 destination = hit.point - ((direction / half)/half);
        quaternion = Quaternion.LookRotation(lookDirection, Vector3.up);
        float distance = Vector3.Distance(transform.position,hit.point);

        if (_isMoving == false && distance > minimalDistance)
        {
            if (direction == transform.forward || direction == -transform.forward)
            {
                Move(destination, hit, direction);

                transform.rotation = quaternion;

                for (int i = 0; i < _tails.Count; i++)
                {
                    _tails[i].TryGetComponent<TailMover>(out TailMover tailMover);
                    tailMover.LookForward(destination - (direction * (i + one)));
                    tailMover.Move(destination - (direction * (i + one)), _moveTime);
                }
            }
            else
            {
                CantMoveEffect();
            }
            
        }
        else
        {
            CantMoveEffect();

            if (hit.collider.TryGetComponent<Obstacle>(out Obstacle obstacle))
            {
                obstacle.PlayEffect(direction);
            }
            if (hit.collider.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
            {
                _coroutine = StartCoroutine(PushSomeone(moveHandler));
            }
        }
    }

    private void Move(Vector3 destination,RaycastHit hit,Vector3 direction)
    {
        _isMoving = true;
        _animationHandler.PlayRunningAnimation();
        _particlesHandler.StartParticles();
        transform.DOMove(destination, _moveTime).SetEase(Ease.Linear);
        _coroutine = StartCoroutine(OffMovingEffects(direction,hit));

        if (hit.collider.TryGetComponent<Border>(out Border border))
        {
            _emotionHandler.ShowHappyEmotion();
            border.SpawnCar(destination);
        }
    }

    private IEnumerator PushSomeone(MoveHandler moveHandler)
    {
        float waitTime = Random.Range(0.1f,0.3f);
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        moveHandler.CantMoveEffect();
    }

    private IEnumerator OffMovingEffects(Vector3 direction, RaycastHit hit)
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        _animationHandler.PlayIdleAnimation();
        _particlesHandler.StopParticles();
        CantMoveEffect();

        if (hit.collider.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            obstacle.PlayEffect(direction);
        }
        if (hit.collider.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
        {
            _coroutine = StartCoroutine(PushSomeone(moveHandler));
        }
        _isMoving = false;
    }
}
