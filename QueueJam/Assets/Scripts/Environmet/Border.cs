using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Border : MonoBehaviour
{
    [SerializeField] private List<Transform> _exitPoints;
    [SerializeField] private GameObject _carPrefab;
    [SerializeField] private GameObject _carAppearanceEffect;
    [SerializeField] private Transform _hidingPoint;

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
            _exitPoints[0] = _firstPoint;
            _handler = moveHandler;
            _coroutine = StartCoroutine(MoveToExitPoint());
        }
    }

    private IEnumerator MoveToExitPoint()
    {
        float delay = 0.2f;
        float speed = 0.4f;
        var wait = new WaitForSeconds(delay);
        var tailWait = new WaitForSeconds((delay / _handler.Tails.Count));

        _handler.TryGetComponent<TailMover>(out TailMover tailMoverFirst);
        _gameObjects.Add(_handler.gameObject);
        tailMoverFirst.Move(_exitPoints[0].transform.position, speed);

        if (_handler.Tails.Count > 0)
        {
            foreach (var tail in _handler.Tails)
            {
                yield return tailWait;
                //tail.gameObject.GetComponent<BoxCollider>().enabled = false;
                tail.TryGetComponent<TailMover>(out TailMover tailMover);
                tailMover.Move(_exitPoints[0].position, speed);
            }
        }

        yield return wait;
        RemoveCharacters();
    }

    private IEnumerator CarAppearance(Vector3 position)
    {
        GameObject effect = Instantiate(_carAppearanceEffect, position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        GameObject car = Instantiate(_carPrefab, position, Quaternion.identity);
        _coroutine = StartCoroutine(OffEffect(effect));
        yield return new WaitForSeconds(1f);
        _coroutine = StartCoroutine(DriveCarToExit(car));
    }

    private IEnumerator DriveCarToExit(GameObject gameObject)
    {
        float time = 1f;
        var wait = new WaitForSeconds(time);

        for (int i = 1; i < _exitPoints.Count; i++)
        {
            gameObject.TryGetComponent<Car>(out Car car);
            car.MoveToExit(_exitPoints[i].position);
            yield return wait;
        }
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
            //gameObject.GetComponent<TailMover>().Move(_hidingPoint.position, 0.1f);
            gameObject.SetActive(false);
        }
    }
}
