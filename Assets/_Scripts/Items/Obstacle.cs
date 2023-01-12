using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class Obstacle : BaseObject
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _defaultColor, _collisionColor;

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _renderer.material.color = _collisionColor;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _renderer.material.color = _defaultColor;
        }
    }
}
