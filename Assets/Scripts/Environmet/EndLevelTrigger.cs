using UnityEngine;
using UnityEngine.Events;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private AudioClip _winSoundFirst;
    [SerializeField] private AudioClip _winSoundSecond;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SaveLevel _saveLevel;
    [SerializeField] private UnityEvent _levelComplete;

    private int _currentValue;
    private int _count = 0;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.TryGetComponent(out Car car))
    //    {
    //        _currentValue++;

    //        if (_currentValue == _value)
    //        {
    //            _audioSource.PlayOneShot(_winSoundFirst);
    //            _audioSource.PlayOneShot(_winSoundSecond);
    //            _winPanel.SetActive(true);
    //            _levelComplete?.Invoke();
    //            _saveLevel.Save();
    //        }
    //    }
    //}

    private void OnEnable()
    {
        Border.Exit += Count;
    }

    private void OnDisable()
    {
        Border.Exit -= Count;
    }

    private void Count()
    {
        _count++;

        if (_count == _value)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        _audioSource.PlayOneShot(_winSoundFirst);
        _audioSource.PlayOneShot(_winSoundSecond);
        _winPanel.SetActive(true);
        _levelComplete?.Invoke();
        _saveLevel.Save();
    }
}