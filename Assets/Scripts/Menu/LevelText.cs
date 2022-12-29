using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _index = 1;
    private const string _levelText = "Leveltext";

    private void Start()
    {
        //_text.text = (_scene.buildIndex).ToString();


        _text.text = PlayerPrefs.GetInt(_levelText).ToString();



        //PlayerPrefs.SetInt(_levelText,495);
    }
}
