using TMPro;
using UnityEngine;

public class PauseScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private const string _score = "Score";

    public void ShowScore()
    {
        _text.text = PlayerPrefs.GetInt(_score).ToString();
    }
}
