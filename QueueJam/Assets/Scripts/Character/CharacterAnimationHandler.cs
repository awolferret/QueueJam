using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayRunningAnimation()
    {
        _animator.Play(CharacterAnimation.Running);
    }

    public void PlayIdleAnimation()
    {
        _animator.Play(CharacterAnimation.Idle);
    }

    public void PlayCantMoveAnimation()
    {
        _animator.Play(CharacterAnimation.CantMove);
    }
}

class CharacterAnimation
{
    public const string Running = "Running";
    public const string Idle = "Idle";
    public const string CantMove = "CantMove";
}