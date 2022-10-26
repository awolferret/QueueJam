using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingCharacterHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private List<AnimationClip> _dances;
    [SerializeField] private List<Material> _materials;

    private void Start()
    {
        _meshRenderer.material = _materials[Random.Range(0, _materials.Count)];
        _animator.Play(_dances[Random.Range(0,_dances.Count)].name);
    }
}
