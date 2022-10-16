using UnityEngine;
using IJunior.TypedScenes;

public class ExitButton : MonoBehaviour
{
    public void LoadMenu()
    {
        float timeGo = 1f;
        Time.timeScale = timeGo;
        Menu.Load();
    }
}
