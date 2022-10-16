using System.Collections;
using UnityEngine;

public class CharacterParticlesHandler : MonoBehaviour
{
    [SerializeField] private GameObject _dustParticles;
    [SerializeField] private GameObject _stopParticles;

    private Coroutine _coroutine;

    public void StartParticles()
    {
        _dustParticles.SetActive(true);
    }

    public void StopParticles()
    {
        _dustParticles.SetActive(false);
        _stopParticles.SetActive(true);
        _coroutine = StartCoroutine(OffParticles());
    }

    private IEnumerator OffParticles()
    {
        float time = 0.1f;
        var waitType = new WaitForSeconds(time);
        yield return waitType;
        _stopParticles.SetActive(false);
    }
}
