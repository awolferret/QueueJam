using System;
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

    private float _moveTime = 0.5f;
    private float _rayDistance = 1f;
    private bool _isMoving = false;
    private Coroutine _coroutine;
    private Vector3 _currentDirection;

    public List<GameObject> Tails => _tails;

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
        Quaternion quaternion;
        Ray ray = new Ray(transform.position, direction);
        Ray backRay = new Ray(transform.position, -direction);
        RaycastHit hit;
        RaycastHit backHit;
        Physics.Raycast(ray, out hit);
        Physics.Raycast(backRay, out backHit, _rayDistance);
        Vector3 lookDirection = hit.point - transform.position;
        quaternion = Quaternion.LookRotation(-lookDirection, Vector3.up);
        Vector3 destination = hit.point - (direction / half);
        float distance = Vector3.Distance(transform.position,hit.point);
        transform.rotation = quaternion;

        if (_isMoving == false && distance > 1)
        {
            if (_tails.Count > 0)
            {
                if (backHit.collider.gameObject == _tails[0].gameObject)
                {
                    _isMoving = true;
                    _animationHandler.PlayRunningAnimation();
                    _particlesHandler.StartParticles();
                    transform.DOMove(destination, _moveTime);
                    _coroutine = StartCoroutine(OffMovingEffects(destination));

                    if (hit.collider.TryGetComponent<Border>(out Border border))
                    {
                        border.SpawnCar(destination);
                    }

                    for (int i = 0; i < _tails.Count; i++)
                    {
                        _tails[i].TryGetComponent<TailMover>(out TailMover tailMover);
                        tailMover.Move(destination - (direction * (i + one)), _moveTime);
                    }
                }
            }
            else
            {
                _isMoving = true;
                transform.rotation = quaternion;
                _animationHandler.PlayRunningAnimation();
                _particlesHandler.StartParticles();
                transform.DOMove(destination, _moveTime);
                _coroutine = StartCoroutine(OffMovingEffects(destination));

                if (hit.collider.TryGetComponent<Border>(out Border border))
                {
                    border.SpawnCar(destination);
                }
            }
        }
        else
        {
            _animationHandler.PlayCantMoveAnimation();
        }
    }

    private IEnumerator OffMovingEffects(Vector3 destination)
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        _animationHandler.PlayIdleAnimation();
        _particlesHandler.StopParticles();
        _isMoving = false;
    }
}
