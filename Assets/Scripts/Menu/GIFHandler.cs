using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GIFHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private Image _targetImage;

    private Coroutine _coroutine;

    public void ShowGif()
    {
        _coroutine = StartCoroutine(ShowGIFCoroutine());
    }

    private void Start()
    {
        _coroutine = StartCoroutine(ShowGIFCoroutine());
    }

    private IEnumerator ShowGIFCoroutine()
    {
        float waitTime = 0.05f;
        var wait = new WaitForSeconds(waitTime);

        for (int i = 0; i < _images.Count; i++)
        {
            _targetImage.sprite = _images[i];
            yield return wait;
        }

        ShowGif();
    }
}
