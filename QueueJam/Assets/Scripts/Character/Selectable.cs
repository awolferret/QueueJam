using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Selectable : MonoBehaviour
{
    private Renderer _renderer;

    public void Selected()
    {
        _renderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        _renderer.material.color = Color.grey;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
}
