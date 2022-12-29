using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScore : MonoBehaviour
{
    private const string _score = "Score";
    private const string _level = "Level";
    private const string _levelText = "Leveltext";
    private int _zero = 0;

    public void SetScoreToZero()
    {
        PlayerPrefs.SetInt(_score, _zero);
        PlayerPrefs.SetInt(_levelText, 1);
    }
}
