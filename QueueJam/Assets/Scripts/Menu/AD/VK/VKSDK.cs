using UnityEngine;
using Agava.VKGames;
using System.Collections;
using System;

public class VKSDK : MonoBehaviour
{
    private bool _isReady = false;
    public static event Action OnRewardViewedVK;

#if VK_GAMES
    private void Awake()
    {
        StartCoroutine(InitializeSDK());
    }
#endif
    private IEnumerator InitializeSDK()
    {
        yield return VKGamesSdk.Initialize();
        ShowInterstitial();
    }

    private IEnumerator AdCooldown()
    {
        float time = 180f;
        var wait = new WaitForSecondsRealtime(time);
        yield return wait;
        _isReady = true;
    }

    public void ShowInterstitial()
    {
        if (_isReady == true)
        {
            Interstitial.Show();
            _isReady = false;
            StartCoroutine(AdCooldown());
        }
    }
#if VK_GAMES
  public void ShowRewardedAds()
  {
      VideoAd.Show(onRewardedCallback: OnRewardViewedVK.Invoke);
  }
#endif
    public void InviteFriends()
    {
        SocialInteraction.InviteFriends();
    }

}
