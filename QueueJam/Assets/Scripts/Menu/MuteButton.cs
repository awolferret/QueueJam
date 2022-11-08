using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image _icon; 
    [SerializeField] private Sprite _muteImage;
    [SerializeField] private Sprite _unmuteImage;

    private float _fullVolume = 1f;

    public void MuteVolume()
    {
        if (AudioListener.volume != 0)
        {
            _icon.sprite = _unmuteImage;
            AudioListener.volume = 0;
        }
        else
        {
            _icon.sprite = _muteImage;
            AudioListener.volume = _fullVolume;
        }
    }
}
