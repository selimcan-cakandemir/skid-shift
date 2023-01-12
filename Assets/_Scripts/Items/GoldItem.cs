using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : BaseItem
{
    public override void OnTriggerEnter(Collider other)
    {
        Actions.OnGoldPickup();
        PlaySound();
        DisappearAnimation();
    }

    public override void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClip);
    }

    public override void DisappearAnimation()
    {
        transform.DOScale(Vector3.zero, 1f);
        _collider.enabled = false;
    }

}
