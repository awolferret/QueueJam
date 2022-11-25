using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGo : MonoBehaviour
{
    private float _timeGo = 1f;

    public void GoTime()
    {
        Time.timeScale = _timeGo;
    }
}
