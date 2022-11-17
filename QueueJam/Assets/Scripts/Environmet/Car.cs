using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Car : MonoBehaviour
{
    [SerializeField] private CarSoundSystem _carSound;

    private float _moveTime = 2f;
    private float _lookIndex = 0.01f;
    private Coroutine _coroutine;

    public void MoveToExit(Vector3[] waypoints)
    {
        Tween tween = transform.DOPath(waypoints, _moveTime, PathType.Linear).SetLookAt(_lookIndex).SetEase(Ease.Linear);
    }

    private void Start()
    {
        _carSound.PlayCarIsReadySound();
        _coroutine = StartCoroutine(CarSounds());
    }

    private IEnumerator CarSounds()
    {
        float effectWait = 0.1f;
        float carWait = 1.5f;
        var effectWaitType = new WaitForSeconds(effectWait);
        var carWaittype = new WaitForSeconds(carWait);
        yield return carWaittype;
        _carSound.PlayCarDoorSound();
        yield return effectWaitType;
        _carSound.PlayCarRideSound();
    }
}
