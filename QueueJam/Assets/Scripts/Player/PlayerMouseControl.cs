using System.Collections;
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour
{
    [SerializeField] private PlayerMouseDetection _mouseDetection;
    [SerializeField] private SwipeDetection _swipeDetection;
    [SerializeField] private GameObject _tutuorialEffect;

    private PlayerInputs _playerInputs;
    private Selectable _currentSelectable;
    private Coroutine _coroutine;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.Player.Select.performed += context => Selected();
        //_playerInputs.Player.Select.canceled += context => Canceled();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();   
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void Selected()
    {
        if (_mouseDetection.TrySelect() != null)
        {
            _currentSelectable = _mouseDetection.TrySelect();
            _currentSelectable.Selected();
            _swipeDetection.OnButtonDown(_mouseDetection.GetMousePosition());

            if (_tutuorialEffect != null)
            {
                _tutuorialEffect.SetActive(false);
            }
        }

        _coroutine = StartCoroutine(Cancel());
    }

    private void Canceled()
    {
        if (_currentSelectable != null)
        {
            _swipeDetection.OnButtonUp(_mouseDetection.GetButtonUpPosition());
            _currentSelectable.OffMove();
            _currentSelectable = null;
        }
    }

    private IEnumerator Cancel()
    {
        yield return new WaitForSeconds(0.15f);
        Canceled();
    }
}
