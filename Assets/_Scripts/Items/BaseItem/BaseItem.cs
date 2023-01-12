using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class BaseItem: MonoBehaviour
{
    [SerializeField] protected UnityEngine.Transform _transform;
    [SerializeField] protected BoxCollider _collider;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _audioClip;

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void PlaySound()
    {

    }

    public virtual void DisappearAnimation()
    {
        
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.RotateAround(_transform.position, Vector3.up, 40 * Time.deltaTime);
    }
}

    

