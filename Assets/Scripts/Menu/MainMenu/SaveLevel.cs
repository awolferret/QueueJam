using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    private int _levelNumber;
    private Scene _scene;
    private const string _level = "Level";
    private const string _levelText = "Leveltext";
    private int _one = 1;
    private int _index = 1;

    public void Save()
    {
        PlayerPrefs.SetInt(_level, _levelNumber);

        if (PlayerPrefs.GetInt(_levelText) < _index)
        {
            PlayerPrefs.SetInt(_levelText, _index);
        }
        _index = PlayerPrefs.GetInt(_levelText);
        _index++;
        PlayerPrefs.SetInt(_levelText, _index);
    }

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        _levelNumber = _scene.buildIndex + _one;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
