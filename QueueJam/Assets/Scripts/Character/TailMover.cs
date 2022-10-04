using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Transform))]

public class TailMover : MonoBehaviour
{
    [SerializeField] private CharacterAnimationHandler _animationHandler;
    [SerializeField] private CharacterParticlesHandler _particlesHandler;

    private Transform _transform;
    private Coroutine _coroutine;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 targetPosition,float moveTime)
    {
        Quaternion quaternion;
        Vector3 lookDirection = targetPosition - transform.position;
        quaternion = Quaternion.LookRotation(-lookDirection, Vector3.up);
        transform.rotation = quaternion;
        _animationHandler.PlayRunningAnimation();
        _particlesHandler.StartParticles();
        transform.DOMove(targetPosition, moveTime);
        _coroutine = StartCoroutine(OffMovingEffects(targetPosition));
    }

    private IEnumerator OffMovingEffects(Vector3 targetPosition)
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        _animationHandler.PlayIdleAnimation();
        _particlesHandler.StopParticles();
    }
}
