using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerCards;

    private const string _leaderboardName = "LevelsPassed";
    private const string _level = "Level";
    private int _currentLevelsPassed;

    private void Awake()
    {
        LoadData();
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
        Authorize();
        SetLeaderboard();
        GetLeaderboard();
        GetLeaderboardPlayer();
    }

    private void LoadData()
    {
        int one = 1;
        _currentLevelsPassed = PlayerPrefs.GetInt(_level) - one;
    }

    private void SetLeaderboard()
    {
        Leaderboard.SetScore(_leaderboardName, _currentLevelsPassed);
    }

    private void Authorize()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }
    }

    private void GetLeaderboard()
    {
        int one = 1;

        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            Debug.Log($"My rank = {result.userRank}");
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                Debug.Log(name + " " + entry.score);
            }

            for (int i = 0; i < _playerCards.Count; i++)
            {
                _playerCards[i].TryGetComponent(out CardHandler cardHandler);
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    name = "Anonymous";
                }

                cardHandler.SetName(name);
                cardHandler.SetScore(result.entries[i].score);
                cardHandler.SetPlace(i + one);
            }
        });
    }

    private void GetLeaderboardPlayer()
    {
        Leaderboard.GetPlayerEntry(_leaderboardName, (result) =>
        {
            if (result == null)
                Debug.Log("Player is not present in the leaderboard.");
            else
                Debug.Log($"My rank = {result.rank}, score = {result.score}");
        });
    }
}
