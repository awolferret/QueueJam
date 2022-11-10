using UnityEngine;
using Agava.VKGames;
using System.Collections;

public class VKSDK : MonoBehaviour
{
    private const string _level = "Level";

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

    public void ShowLeaderboard()
    {
        int one = 1;
        Leaderboard.ShowLeaderboard(PlayerPrefs.GetInt(_level) - one);
    }
}
