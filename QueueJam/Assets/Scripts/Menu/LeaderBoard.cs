using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames.Samples;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private const string LeaderboardName = "LevelsPassed";
    private const string DataKey = "Levels";

    private int _currentLevelsPassed;

    private void Awake()
    {
        //LoadData();
        print(_currentLevelsPassed);
    }

    //private IEnumerator Start()
    //{
    //    yield return YandexGamesSdk.Initialize();
    //    Authorize();
    //    SetLeaderboard();
    //    GetLeaderboard();
    //    GetLeaderboardPlayer();
    //}

    //private void LoadData()
    //{ 
    //    var data = SaveLoadData.Load<>
    //}
}
