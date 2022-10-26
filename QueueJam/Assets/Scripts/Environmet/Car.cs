using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    [SerializeField] private CarSoundSystem _carSound;

    private float _moveTime = 2f;

    public void MoveToExit(Vector3[] waypoints)
    {
        Tween tween = transform.DOPath(waypoints, _moveTime, PathType.Linear).SetLookAt(0.01f).SetEase(Ease.Linear);
    }

    private void Start()
    {
        _carSound.PlayCarIsReadySound();
    }
}
