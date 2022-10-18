using UnityEngine;

public class AnimationOffset : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _one = 1f;
    private const string offset = "Random";

    private void Start()
    {
        _animator.SetFloat(offset, Random.Range(0f, _one));
    }
}