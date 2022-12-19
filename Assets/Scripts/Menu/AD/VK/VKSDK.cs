using UnityEngine;
using Agava.VKGames;
using System.Collections;
using System;

public class VKSDK : MonoBehaviour
{
    public static event Action OnRewardViewedVK;

    private float _fullVolume = 1f;
    private string _adPlaying = "AdPlaying";

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
#if VK_GAMES
    public void ShowInterstitial()
    {
        Interstitial.Show();
    }
#endif

#if VK_GAMES
  public void ShowRewardedAds()
  {
      VideoAd.Show(onRewardedCallback: OnRewardViewedVK.Invoke);
      AudioListener.volume = 0f;
      PlayerPrefs.SetInt(_adPlaying,1);
  }
#endif
    public void InviteFriends()
    {
        SocialInteraction.InviteFriends();
    }

}
