using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private int _levelNumber;
    private Scene _scene;
    private const string _level = "Level";
    private int _one = 1;

    public void Save()
    {
        PlayerPrefs.SetInt(_level, _levelNumber);
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
