using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private CarSoundSystem _carSound;
    public void MoveToExit(Vector3 destination)
    {
        transform.LookAt(destination);
        transform.DOMove(destination, 1f);
    }

    private void Start()
    {
        _carSound.PlayCarIsReadySound();
    }
}
