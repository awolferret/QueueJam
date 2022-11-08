using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    [SerializeField] TMP_Text _place;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _score;

    public void SetPlace(int place)
    {
        _place.text = place.ToString();
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}