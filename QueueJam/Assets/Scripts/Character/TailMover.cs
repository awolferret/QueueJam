using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TailMover : MonoBehaviour
{
    [SerializeField] private CharacterAnimationHandler _animationHandler;
    [SerializeField] private CharacterParticlesHandler _particlesHandler;

    private Coroutine _coroutine;

    public void Move(Vector3 targetPosition,float moveTime)
    {
        Quaternion quaternion;
        Vector3 lookDirection = targetPosition - transform.position;
        quaternion = Quaternion.LookRotation(-lookDirection, Vector3.up);
        transform.rotation = quaternion;
        _animationHandler.PlayRunningAnimation();
        _particlesHandler.StartParticles();
        transform.DOMove(targetPosition, moveTime);
        _coroutine = StartCoroutine(OffMovingEffects());
    }

    private IEnumerator OffMovingEffects()
    {
        float waitTime = 0.5f;
        var wait = new WaitForSeconds(waitTime);
        yield return wait;
        _animationHandler.PlayIdleAnimation();
        _particlesHandler.StopParticles();
    }
}
