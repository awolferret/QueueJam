using UnityEngine;
using Agava.VKGames;
using System.Collections;
using System;

public class VKSDK : MonoBehaviour
{
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
    }

    public void ShowInterstitial()
    {
        Interstitial.Show();
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
