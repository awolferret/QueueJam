using UnityEngine;
using Agava.VKGames;
using UnityEngine.UI;
using System.Collections;

public class VKSDK : MonoBehaviour
{
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

    public void ShowInterstitial()
    {
        Interstitial.Show();
    }

    public void ShowRewardedAds()
    {
        VideoAd.Show();
    }

    public void InviteFriends()
    {
        SocialInteraction.InviteFriends();
    }


}
