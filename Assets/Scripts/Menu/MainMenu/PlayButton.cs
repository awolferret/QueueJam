using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private int _levelToLoad;
    private const string _level = "Level";
    private int _firstLevelIndex = 1;

    public void LoadLevel()
    {
        _levelToLoad = PlayerPrefs.GetInt(_level);

        if (_levelToLoad == 0)
        {
            _levelToLoad = _firstLevelIndex;
        }

        SceneManager.LoadScene(_levelToLoad);
    }
}
