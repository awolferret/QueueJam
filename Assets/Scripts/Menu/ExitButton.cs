using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void LoadMenu()
    {
        float timeGo = 1f;
        Time.timeScale = timeGo;
        SceneManager.LoadScene(0); ;
    }
}
