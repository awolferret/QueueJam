using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBlock : MonoBehaviour
{
    private GameObject _gameObject;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    //private void FixedUpdate()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    Debug.DrawRay(transform.position, transform.forward, Color.red);
    //    RaycastHit hit;
    //    Physics.Raycast(ray, out hit,10);

    //    if (hit.collider.gameObject != _gameObject)
    //    {
    //      if (hit.collider.TryGetComponent<TailMover>(out TailMover tailMover))
    //      {
    //          _gameObject = hit.collider.gameObject;
    //          tailMover.Move(_transform.position);
    //          Debug.Log("1");
    //      }
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("1");
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("1");
    //}
}