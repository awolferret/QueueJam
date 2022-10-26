using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private GameObject _carPrefab;
    [SerializeField] private GameObject _carAppearanceEffect;

    private Coroutine _coroutine;
    private MoveHandler _handler;
    private Transform _firstPoint;
    private List<GameObject> _gameObjects;

    private void Start()
    {
        _gameObjects = new List<GameObject>();
    }

    public void SpawnCar(Vector3 position)
    {
        _coroutine = StartCoroutine(CarAppearance(position));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MoveHandler>(out MoveHandler moveHandler))
        {
            _firstPoint = moveHandler.gameObject.transform;
            _handler = moveHandler;
            _coroutine = StartCoroutine(MoveToExitPoint());
        }
    }

    private IEnumerator MoveToExitPoint()
    {
        float delay = 0.2f;
        float speed = 0.4f;
        float animationTime = 0.5f;
        var wait = new WaitForSeconds(delay);
        var animationWait = new WaitForSeconds(animationTime * _gameObjects.Count);
        var tailWait = new WaitForSeconds((delay / _handler.Tails.Count));

        _handler.TryGetComponent<TailMover>(out TailMover tailMoverFirst);
        _gameObjects.Add(_handler.gameObject);
        tailMoverFirst.Move(_firstPoint.position, speed);

        if (_handler.Tails.Count > 0)
        {
            foreach (var tail in _handler.Tails)
            {
                yield return tailWait;
                tail.TryGetComponent<TailMover>(out TailMover tailMover);
                tailMover.Move(_firstPoint.position, speed);
            }
        }

        yield return animationWait;
        RemoveCharacters();
    }

    private IEnumerator CarAppearance(Vector3 position)
    {
        float effectWait = 0.1f;
        float carWait = 1.5f;
        var effectWaitType = new WaitForSeconds(effectWait);
        var carWaittype = new WaitForSeconds(carWait);
        Vector3 gap = new Vector3(0, 0.3f, 0);
        Vector3 carSpawnPosition = position + gap;
        GameObject effect = Instantiate(_carAppearanceEffect, position, Quaternion.identity);
        yield return effectWaitType;
        GameObject car = Instantiate(_carPrefab, carSpawnPosition, Quaternion.identity);
        car.transform.LookAt(_waypoints[0]);
        _coroutine = StartCoroutine(OffEffect(effect));
        yield return carWaittype;
        car.GetComponent<CarSoundSystem>().PlayCarDoorSound();
        yield return effectWaitType;
        car.GetComponent<CarSoundSystem>().PlayCarRideSound();
        DriveToExit(car);
    }

    private void DriveToExit(GameObject gameObject)
    { 
        gameObject.TryGetComponent<Car>(out Car car);
        car.MoveToExit(_waypoints);
    }

    private IEnumerator OffEffect(GameObject effect)
    {
        float time = 0.5f;
        var wait = new WaitForSeconds(time);
        yield return wait;
        effect.SetActive(false);
    }

    private void RemoveCharacters()
    {
        foreach (var gameObject in _gameObjects)
        {
            SkinnedMeshRenderer[] array = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            gameObject.GetComponent<BoxCollider>().enabled = false;

            foreach (var item in array)
            {
                item.enabled = false;
            }
        }

        _gameObjects.Clear();
    }
}
