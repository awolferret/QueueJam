using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private Scene _scene;
    private int _one = 1;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + _one);
    }

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }
}
