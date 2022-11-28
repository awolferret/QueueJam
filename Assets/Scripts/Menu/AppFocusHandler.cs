using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFocusHandler : MonoBehaviour
{
    private string _audioSaveName = "AudioSave";

    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.pause = silence;
        AudioListener.volume = silence ? 0 : 1;
    }
}
