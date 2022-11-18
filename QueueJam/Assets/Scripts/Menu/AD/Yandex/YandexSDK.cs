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

#endif
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR 
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();
        ShowBannerAd();
    }
#if YANDEX_GAMES 
    public void ShowRewardAd()
    {
        VideoAd.Show(onRewardedCallback: OnRewardViewedYandex.Invoke);
    }
#endif
    private void ShowBannerAd()
    {
        InterstitialAd.Show();
    }
}
