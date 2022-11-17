using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInCarEffectsHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _getInCarEffects;
    [SerializeField] private BorderSoundSystem _borderSound;

    private Coroutine _coroutine;
    private List<GameObject> _gameObjects;
    private MoveHandler _handler;
    private CarAnimationHandler _animationHandler;
    int index = -1;

    private void Start()
    {
        _gameObjects = new List<GameObject>();
    }

    public void SetCar(GameObject car)
    {
        if (car.TryGetComponent(out CarAnimationHandler carAnimation))
        {
            _animationHandler = carAnimation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int minusOne = -1;

        if (other.gameObject.TryGetComponent(out MoveHandler moveHandler))
        {
            index++;

            if (_gameObjects.Count == 0)
            {
                _handler = moveHandler;
                _gameObjects = _handler.Tails;
            }
            else
            {
                if (index >= _gameObjects.Count)
                {
                    _coroutine = StartCoroutine(ShowGetInCarEffect(_gameObjects.Count,other.transform));
                    index = minusOne;
                    _gameObjects.Clear();
                }
            }
        }
    }

    private IEnumerator ShowGetInCarEffect(int index, Transform spawnPoint)
    {
        float wait = 2f;
        var waitType = new WaitForSeconds(wait);
        GameObject activeEffect = Instantiate(_getInCarEffects[index], spawnPoint.position, Quaternion.LookRotation(Vector3.up));
        _borderSound.PlaySound(index);
        yield return waitType;
        activeEffect.SetActive(false);
    }
}
