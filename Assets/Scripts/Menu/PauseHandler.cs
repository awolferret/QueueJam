using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _retryButton;

    public void OpenPausePanel(GameObject pausePanel)
    {
        pausePanel.SetActive(true);
        _pauseButton.enabled = false;
        _retryButton.enabled = false;
        Time.timeScale = 0;
    }

    public void ClosePausePanel(GameObject pausePanel)
    {
        float timeGo = 1f;
        pausePanel.SetActive(false);
        _pauseButton.enabled = true;
        _retryButton.enabled = true;
        Time.timeScale = timeGo;
    }
}
