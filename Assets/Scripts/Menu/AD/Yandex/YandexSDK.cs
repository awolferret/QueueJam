using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using System;

public class YandexSDK : MonoBehaviour
{
    public static event Action OnRewardViewedYandex;
    public static event Action AdStarted;

    private string _adPlaying = "AdPlaying";
    private string _volume = "Volume";

#if YANDEX_GAMES 
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private void OnEnable()
    {
        EndLevelTrigger.LevelEnd += ShowBannerAd;
        AdStarted += SoundHandler;
    }

    private void OnDisable()
    {
        EndLevelTrigger.LevelEnd -= ShowBannerAd;
        AdStarted -= SoundHandler;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR 
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();
        PlayerPrefs.SetFloat(_volume, AudioListener.volume);
        ShowBannerAd();
    }

    public void ShowRewardAd()
    {
        VideoAd.Show(onOpenCallback: AdStarted.Invoke, onRewardedCallback: OnRewardViewedYandex.Invoke);
    }

    private void SoundHandler()
    {
        AudioListener.volume = 0f;
        PlayerPrefs.SetInt(_adPlaying, 1);
    }

    public void ShowBannerAd()
    {
        InterstitialAd.Show();
    }
#endif
}
