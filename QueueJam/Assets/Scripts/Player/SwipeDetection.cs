using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 _mouseDownPoint;
    private Vector2 _mouseUpPoint;
    private Vector2 _delta;
    private float _minimalDisatanse;
    public static event OnSwipeInput SwipeInput;
    public delegate void OnSwipeInput(Vector3 direction);

    public void OnButtonDown(Vector3 mouseDownPoint)
    {
        _mouseDownPoint = new Vector2(mouseDownPoint.x, mouseDownPoint.z);
    }

    public void OnButtonUp(Vector3 mouseUpPoint)
    {
        _mouseUpPoint = new Vector2(mouseUpPoint.x, mouseUpPoint.z);
        CheckSwipe(_mouseUpPoint);
    }

    private void CheckSwipe(Vector3 mouseUpPoint)
    {
        _delta = Vector2.zero;
        _delta = (Vector2)mouseUpPoint - _mouseDownPoint;

        if (_delta.magnitude > _minimalDisatanse)
        {
            if (Mathf.Abs(_delta.x) > Mathf.Abs(_delta.y))
            {
                if (_delta.x > 0)
                {
                    SwipeInput(Vector3.right);
                }
                else
                {
                    SwipeInput(Vector3.left);
                }
            }
            else
            {
                if (_delta.y > 0)
                {
                    SwipeInput(Vector3.forward);
                }
                else
                {
                    SwipeInput(Vector3.back);
                }
            }
        }
    }
}