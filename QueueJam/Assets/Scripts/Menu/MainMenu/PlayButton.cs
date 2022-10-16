using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private int _levelToLoad;
    private const string _level = "Level";
    private int _one = 1;
    private int _two = 2;

    public void LoadLevel()
    {
        _levelToLoad = PlayerPrefs.GetInt(_level);

        if (_levelToLoad == _one || _levelToLoad == 0)
        {
            _levelToLoad = _two;
        }

        SceneManager.LoadScene(_levelToLoad);
    }
}
