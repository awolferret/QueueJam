using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(MoveHandler))]

public class Selectable : MonoBehaviour
{
    private Renderer _renderer;
    private MoveHandler _moveHandler;

    public void Selected()
    {
        _renderer.material.color = Color.yellow;
        _moveHandler.enabled = true;
    }

    public void Deselect()
    {
        _renderer.material.color = Color.grey;

    }

    public void OffMove()
    {
        _moveHandler.enabled = false;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _moveHandler = GetComponent<MoveHandler>();
    }
}
