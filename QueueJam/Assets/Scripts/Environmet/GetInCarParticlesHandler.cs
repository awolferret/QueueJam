using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInCarParticlesHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> _getInCarEffects;

    private Coroutine _coroutine;
    private List<GameObject> _gameObjects;
    private MoveHandler _handler;
    int index = -1;

    private void Start()
    {
        _gameObjects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
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
                    index = -1;
                    _gameObjects.Clear();
                }
            }
        }
    }



    private void Update()
    {
        Debug.Log(_gameObjects.Count);
    }

    private IEnumerator ShowGetInCarEffect(int index, Transform spawnPoint)
    {
        GameObject activeEffect = Instantiate(_getInCarEffects[index], spawnPoint.position, Quaternion.LookRotation(Vector3.up));
        yield return new WaitForSeconds(1.5f);
        activeEffect.SetActive(false);
    }
}
