using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private Scene _scene;
    private int _one = 1;

    public void LoadNextLevel()
    {
        StartCoroutine(NextScene());
    }

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private IEnumerator NextScene()
    {
        float time = 0.1f;
        var wait = new WaitForSecondsRealtime(time);
        yield return wait;
        SceneManager.LoadScene(_scene.buildIndex + _one);
    }
}