using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image _icon; 
    [SerializeField] private Sprite _muteImage;
    [SerializeField] private Sprite _unmuteImage;

    private float _fullVolume = 1f;
    private string _volumeMuted = "VolumeMuted";
    private string _volume = "Volume";

    private void Update()
    {
        if (AudioListener.volume != 0)
        {
            _icon.sprite = _muteImage;
        }
        else
        {
            _icon.sprite = _unmuteImage;
        }
    }

    public void MuteVolume()
    {
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt(_volumeMuted,1);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat(_volume);//_fullVolume;
            PlayerPrefs.SetInt(_volumeMuted, 0);
            PlayerPrefs.SetFloat(_volume, AudioListener.volume);
        }
    }
}
