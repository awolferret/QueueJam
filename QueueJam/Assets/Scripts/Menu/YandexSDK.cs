using System.Collections;
using Agava.YandexGames;
using UnityEngine.Events;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    //private UnityEvent _onRewardViewed = new UnityEvent();

    //public event UnityAction OnRewardViewed
    //{
    //    add => _onRewardViewed.AddListener(value);
    //    remove => _onRewardViewed.RemoveListener(value);
    //}

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
        VideoAd.Show();//onRewardedCallback: _onRewardViewed.Invoke);
    }

    private void ShowBannerAd()
    {
        InterstitialAd.Show();
    }
}
