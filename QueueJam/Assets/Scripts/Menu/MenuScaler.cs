using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScaler : MonoBehaviour
{
    [SerializeField] private GameObject _desktopCanvas;
    [SerializeField] private GameObject _smartphoneCanvas;

    private void Update()
    {
        if (Screen.width > Screen.height)
        {
            _desktopCanvas.SetActive(true);
            _smartphoneCanvas.SetActive(false);
        }
        else
        {
            _desktopCanvas.SetActive(false);
            _smartphoneCanvas.SetActive(true);
        }
    }
}
