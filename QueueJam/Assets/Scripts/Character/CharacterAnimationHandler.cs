using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Coroutine _coroutine;
    private bool _isSelected = false;

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

    public void PlaySelectedAnimation()
    {
        _isSelected = true;
        _animator.Play(CharacterAnimation.Selected);
        _coroutine = StartCoroutine(SelectedCoroutine());
    }

    public void Deselect()
    {
        _isSelected = false;
        _coroutine = StartCoroutine(OffSelectedAnimation());
    }

    private IEnumerator SelectedCoroutine()
    {
        float time = 1f;
        var waitType = new WaitForSeconds(time);

        while (_isSelected == true)
        {
            yield return waitType;
        }
    }

    private IEnumerator OffSelectedAnimation()
    {
        float time = 1f;
        var waitType = new WaitForSeconds(time);
        yield return waitType;
        PlayIdleAnimation();
    }
}

class CharacterAnimation
{
    public const string Running = "Running";
    public const string Idle = "Idle";
    public const string CantMove = "CantMove";
    public const string Selected = "Selected";
}