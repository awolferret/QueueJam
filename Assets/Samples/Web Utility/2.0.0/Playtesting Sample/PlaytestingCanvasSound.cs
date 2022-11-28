using UnityEngine;

namespace Agava.WebUtility.Samples
{
    public class PlaytestingCanvasSound : MonoBehaviour
    {
        private string _volumeMuted = "VolumeMuted";

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            // Use both pause and volume muting methods at the same time.
            // They're both broken in Web, but work perfect together. Trust me on this.
            AudioListener.pause = inBackground;

            if (PlayerPrefs.GetInt(_volumeMuted) == 0)
            {
                AudioListener.volume = inBackground ? 0f : 1f;
            }
        }
    }
}
