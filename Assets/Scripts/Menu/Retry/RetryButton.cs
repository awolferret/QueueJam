using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private Scene _scene;

    public void Reload()
    {
        SceneManager.LoadScene(_scene.buildIndex);
    }

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }
}
