using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    public void MoveToExit(Vector3 destination)
    {
        transform.LookAt(destination);
        transform.DOMove(destination, 1f);
    }
}
