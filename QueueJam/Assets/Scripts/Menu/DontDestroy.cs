using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _SoundSystem;

    private void Awake()
    {
        DontDestroyOnLoad(_SoundSystem);
    }
}
