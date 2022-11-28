using System.Collections;
using Agava.YandexGames;
using UnityEngine.Events;
using UnityEngine;
using System;

public class YandexSDK : MonoBehaviour
{
    public static event Action OnRewardViewedYandex;

#if YANDEX_GAMES 
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }


    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR 
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();
        ShowBannerAd();
    }

    public void ShowRewardAd()
    {
        VideoAd.Show(onRewardedCallback: OnRewardViewedYandex.Invoke);
        AudioListener.volume = 0f;
    }

    public void ShowBannerAd()
    {
        InterstitialAd.Show();
    }
#endif
}
