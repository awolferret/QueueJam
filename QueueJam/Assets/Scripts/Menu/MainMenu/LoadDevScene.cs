using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDevScene : MonoBehaviour
{
    private int _firstScene = 1;

    public void Load()
    {
        SceneManager.LoadScene(_firstScene);
    }
}
