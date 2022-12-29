using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Border : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private List<GameObject> _carPrefabs;
    [SerializeField] private GameObject _carAppearanceEffect;
    [SerializeField] private GetInCarEffectsHandler _effectsHandler;

    private Coroutine _coroutine;
    private MoveHandler _handler;
    private Transform _firstPoint;
    private List<GameObject> _gameObjects;

    public static event UnityAction Exit;

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
        if (other.gameObject.TryGetComponent(out MoveHandler moveHandler))
        {
            _firstPoint = moveHandler.gameObject.transform;
            _handler = moveHandler;
            _coroutine = StartCoroutine(MoveToExitPoint());
            Exit?.Invoke();
        }
    }

    private IEnumerator MoveToExitPoint()
    {
        float delay = 0.2f;
        float speed = 0.4f;
        float animationTime = 0.5f;
        var animationWait = new WaitForSeconds(animationTime * _gameObjects.Count);
        var tailWait = new WaitForSeconds((delay / _handler.Tails.Count));
        _handler.TryGetComponent(out TailMover tailMoverFirst);
        _gameObjects.Add(_handler.gameObject);
        tailMoverFirst.Move(_firstPoint.position, speed);

        foreach (var tail in _handler.Tails)
        {
            yield return tailWait;
            tail.TryGetComponent<TailMover>(out TailMover tailMover);
            tailMover.Move(_firstPoint.position, speed);
        }

        yield return animationWait;
        RemoveCharacters();
    }

    private IEnumerator CarAppearance(Vector3 position)
    {
        float effectWait = 0.1f;
        float carWait = 1.5f;
        float gapSize = 0.3f;
        var effectWaitType = new WaitForSeconds(effectWait);
        var carWaitType = new WaitForSeconds(carWait);
        Vector3 gap = new Vector3(0, gapSize, 0);
        Vector3 carSpawnPosition = position + gap;
        GameObject effect = Instantiate(_carAppearanceEffect, position, Quaternion.identity);
        yield return effectWaitType;
        GameObject car = Instantiate(_carPrefabs[Random.Range(0,_carPrefabs.Count)], carSpawnPosition, Quaternion.identity);
        _effectsHandler.SetCar(car);
        car.transform.LookAt(_waypoints[0]);
        _coroutine = StartCoroutine(OffEffect(effect));
        yield return carWaitType;
        DriveToExit(car);
    }

    private void DriveToExit(GameObject gameObject)
    { 
        gameObject.TryGetComponent(out Car car);
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
