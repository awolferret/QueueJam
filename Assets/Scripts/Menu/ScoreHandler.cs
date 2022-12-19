using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _winPanelCurrentText;

    private int _score;
    private int _currentScore = 0;
    private int _double = 2;
    private float _soundOn = 1f;
    private const string _scoreName = "Score";
    private string _volumeMuted = "VolumeMuted";
    private string _adPlaying = "AdPlaying";

    public void AddScore(int multiplier)
    {
        _currentScore += 10 * (multiplier + 1);
    }

    public void SaveScore()
    {
        _score += _currentScore;
        PlayerPrefs.SetInt(_scoreName, _score);
    }

    private void Start()
    {
        _currentScore = 0;
        _score = PlayerPrefs.GetInt(_scoreName);
    }

    public void WatchAd()
    {
        _currentScore *= 2;
        _winPanelCurrentText.text = _currentScore.ToString();

        if (PlayerPrefs.GetInt(_volumeMuted) == 0)
        {
            PlayerPrefs.SetInt(_adPlaying, 0);
            AudioListener.volume = 1f;
        }
    }

    private void Update()
    {
        _currentScoreText.text = _currentScore.ToString();

        if (_winPanelCurrentText.enabled == true)
        {
            _winPanelCurrentText.text = _currentScore.ToString();
            _scoreText.text = PlayerPrefs.GetInt(_scoreName).ToString();
        }
    }

    private void OnEnable()
    {
        YandexSDK.OnRewardViewedYandex += WatchAd;
        VKSDK.OnRewardViewedVK += WatchAd;
    }

    private void OnDisable()
    {
        YandexSDK.OnRewardViewedYandex -= WatchAd;
        VKSDK.OnRewardViewedVK -= WatchAd;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
