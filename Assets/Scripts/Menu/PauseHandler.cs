using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _retryButton;
    [SerializeField] private GameObject _muteButton;
    [SerializeField] private GameObject _leaderboard;

    public void OpenPausePanel(GameObject pausePanel)
    {
        pausePanel.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
        _retryButton.gameObject.SetActive(false);
        _muteButton.SetActive(false);
        _leaderboard.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosePausePanel(GameObject pausePanel)
    {
        float timeGo = 1f;
        pausePanel.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _retryButton.gameObject.SetActive(true);
        _muteButton.SetActive(true);
        _leaderboard.SetActive(true);
        Time.timeScale = timeGo;
    }

    private void OnEnable()
    {
        EndLevelTrigger.LevelEnd += OffButtons;
    }

    private void OnDisable()
    {
        EndLevelTrigger.LevelEnd -= OffButtons;
    }

    private void OffButtons()
    {
        _pauseButton.gameObject.SetActive(false);
        _retryButton.gameObject.SetActive(false);
        _muteButton.SetActive(false);
        _leaderboard.SetActive(false);
    }
}
