using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _onPicture;
    [SerializeField] private Sprite _midPicture;
    [SerializeField] private Sprite _offPicture;

    public void ChangeVolume()
    {
        float half = 0.5f;
        AudioListener.volume = _slider.value;

        if (_slider.value == 0)
        {
            _image.sprite = _offPicture;
        }
        if (_slider.value < half && _slider.value > 0)
        {
            _image.sprite = _midPicture;
        }
        if (_slider.value >= half)
        {
            _image.sprite = _onPicture;
        }
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
