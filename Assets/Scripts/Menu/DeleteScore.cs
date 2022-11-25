using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScore : MonoBehaviour
{
    private const string _score = "Score";
    private int _zero = 0;

    public void SetScoreToZero()
    {
        PlayerPrefs.SetInt(_score, _zero);
    }
}
