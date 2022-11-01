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

    public List<GameObject> Tails => _tails;

    public void Pushed()
    {
        _animationHandler.PlayCantMoveAnimation();
        _emotionHandler.ShowAngryEmotion();
    }

    private void CantMoveEffect(RaycastHit hit, Vector3 direction,float distance)
    {
        Pushed();

        if (distance <= 1)
        {
            if (hit.collider.TryGetComponent(out Obstacle obstacle))
            {
                obstacle.PlayEffect(direction);
            }
            if (hit.collider.TryGetComponent(out MoveHandler moveHandler))
            {
                _coroutine = StartCoroutine(PushSomeone(moveHandler));
            }
        }

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
        RaycastHit targetHit;
        Physics.Raycast(ray, out targetHit);
        Vector3 lookDirection = targetHit.point - transform.position;
        Vector3 destination = targetHit.point - ((direction / half)/half);
        quaternion = Quaternion.LookRotation(lookDirection, Vector3.up);
        float distance = Vector3.Distance(transform.position,targetHit.point);

        if (_isMoving == false && distance > minimalDistance)
        {
            if (direction == transform.forward || direction == -transform.forward)
            {
                Move(destination, targetHit, direction, distance);

                transform.rotation = quaternion;

                for (int i = 0; i < _tails.Count; i++)
                {
                    _tails[i].TryGetComponent<TailMover>(out TailMover tailMover);
                    tailMover.LookForward(destination - (direction * (i + one) / half));
                    tailMover.Move(destination - (direction * (i + one)), _moveTime);
                }
            }
            else
            {
                CantMoveEffect(targetHit,direction, distance);
            }
            
        }
        else
        {
            CantMoveEffect(targetHit, direction, distance);
        }
    }

    private void Move(Vector3 destination,RaycastHit hit,Vector3 direction,float distance)
    {
        _isMoving = true;
        _animationHandler.PlayRunningAnimation();
        _particlesHandler.StartParticles();
        transform.DOMove(destination, _moveTime).SetEase(Ease.Linear);
        _coroutine = StartCoroutine(OffMovingEffects(direction,hit, distance));

        if (hit.collider.TryGetComponent<Border>(out Border border))
        {
            _emotionHandler.ShowHappyEmotion();
            border.SpawnCar(destination);
        }
    }

    private IEnumerator PushSomeone(MoveHandler moveHandler)
    {
        float minWait = 0.05f;
        float maxWait = 0.2f;
        float waitTime = Random.Range(minWait, maxWait);
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        moveHandler.Pushed();
    }

    private IEnumerator OffMovingEffects(Vector3 direction, RaycastHit hit,float distance)
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        _animationHandler.PlayIdleAnimation();
        _particlesHandler.StopParticles();
        CantMoveEffect(hit, direction, distance);
        _isMoving = false;
    }
}
