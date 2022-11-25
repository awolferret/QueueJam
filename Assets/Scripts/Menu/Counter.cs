using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _currentLevelPassed = 0;

    public int CurrentLevelPassed => _currentLevelPassed;

    public void LevelPassed()
    {
        _currentLevelPassed++;
    }
}
