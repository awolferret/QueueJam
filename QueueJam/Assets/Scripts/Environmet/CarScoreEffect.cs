using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScoreEffect : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<AnimationClip> _scoreEffects;

    public void PlayEffect(int index)
    {
        _animator.Play(_scoreEffects[index].name);
    }
}
