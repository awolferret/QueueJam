using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CharacterSoundSystem : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _walkSounds;
    [SerializeField] private AudioClip _emotionSound;

    private AudioSource _audioSource;

    public void Step()
    {
        AudioClip clip = GetRandomClip();
        _audioSource.PlayOneShot(clip);
    }

    public void PlayEmotionSound()
    {
        _audioSource.PlayOneShot(_emotionSound);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, _walkSounds.Count);
        return _walkSounds[index];
    }
}
