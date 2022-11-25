using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CarSoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _carIsReady;
    [SerializeField] private AudioClip _getInCarSound;
    [SerializeField] private AudioClip _carDoor;
    [SerializeField] private AudioClip _carRideSound;
    [SerializeField] private AudioSource _audioSource;

    public void PlayCarIsReadySound()
    {
        _audioSource.PlayOneShot(_carIsReady);
    }

    public void PlayGetInCarSound()
    {
        _audioSource.PlayOneShot(_getInCarSound);
    }

    public void PlayCarDoorSound()
    {
        _audioSource.PlayOneShot(_carDoor);
    }

    public void PlayCarRideSound()
    {
        _audioSource.PlayOneShot(_carRideSound);
    }
}
