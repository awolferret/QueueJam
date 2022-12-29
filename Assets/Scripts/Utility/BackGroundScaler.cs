using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScaler : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;

    [SerializeField] private float _horizontalHeight;
    [SerializeField] private float _horizontalWidth;    
    [SerializeField] private float _verticalHeight;
    [SerializeField] private float _verticalWidth;


    private void Update()
    {
        if (Screen.height > Screen.width)
        {
            //_height = 1280;
            //_width = 1735;
            _transform.sizeDelta = new Vector2(_verticalWidth, _verticalHeight);
        }
        else
        {
            //_height = 670;
            //_width = 1176;
            _transform.sizeDelta = new Vector2(_horizontalWidth, _horizontalHeight);
        }
    }
}
