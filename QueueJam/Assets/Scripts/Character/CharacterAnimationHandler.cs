using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Coroutine _coroutine;
    private bool _selected = false;

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
        _selected = true;
        _animator.Play(CharacterAnimation.Selected);
        _coroutine = StartCoroutine(SelectedCoroutine());
    }

    public void Deselect()
    {
        _selected = false;
        PlayIdleAnimation();
    }

    private IEnumerator SelectedCoroutine()
    {
        float time = 1f;
        var waitType = new WaitForSeconds(time);

        while (_selected == true)
        {
            yield return waitType;
        }
    }
}

class CharacterAnimation
{
    public const string Running = "Running";
    public const string Idle = "Idle";
    public const string CantMove = "CantMove";
    public const string Selected = "Selected";
}