using System.Collections;
using Agava.YandexGames;
using UnityEngine.Events;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{

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

    public void ShowRewardAd()
    {
        VideoAd.Show();
    }

    private void ShowBannerAd()
    {
        InterstitialAd.Show();
    }
}
