using System.Collections.Generic;
using UnityEngine;

public class BorderSoundSystem : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioList;
    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(int index)
    {
        _audioSource.PlayOneShot(_audioList[index]);
    }
}
