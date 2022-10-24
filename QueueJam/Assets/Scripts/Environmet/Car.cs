using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    [SerializeField] private CarSoundSystem _carSound;

    private float _moveTime = 0.5f;

    public void MoveToExit(Vector3 destination)
    {
        transform.LookAt(destination);
        transform.DOMove(destination, _moveTime).SetEase(Ease.Linear);
    }

    private void Start()
    {
        _carSound.PlayCarIsReadySound();
    }
}
