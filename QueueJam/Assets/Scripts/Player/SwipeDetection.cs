using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 _mouseDownPoint;
    private Vector2 _mouseUpPoint;

    public void OnButtonDown(Vector3 mouseDownPoint)
    {
        Debug.Log(mouseDownPoint);
    }

    public void OnButtonUp(Vector3 mouseUpPoint)
    {
        Debug.Log(mouseUpPoint);
    }
}
