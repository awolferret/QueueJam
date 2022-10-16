using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Scene _scene;
    private int _one = 1;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        _text.text = (_scene.buildIndex- _one).ToString();
    }
}
