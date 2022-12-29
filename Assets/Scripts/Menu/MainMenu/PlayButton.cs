using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private int _levelToLoad;
    private const string _level = "Level";
    private const string _levelText = "Leveltext";
    private int _index = 1;
    private int _firstLevelIndex = 1;

    public void LoadLevel()
    {
        _levelToLoad = PlayerPrefs.GetInt(_level);

        if (PlayerPrefs.GetInt(_levelText) < _index)
        {
            PlayerPrefs.SetInt(_levelText, _index);
        }

        if (_levelToLoad == 0)
        {
            _levelToLoad = _firstLevelIndex;
        }
        if (_levelToLoad == 50)
        { 
            _levelToLoad = Random.Range(15,49);
        }
        SceneManager.LoadScene(_levelToLoad);
    }
}
