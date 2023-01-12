using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressAnyKey : MonoBehaviour
{
    [SerializeField] private GameObject _menuParent;
    [SerializeField] private float _popDuration;

    Tween popTween;

    void Start()
    {
        Pop(this.gameObject);
    }   

    void Update()
    {
        if (Input.anyKey)
        {
            this.gameObject.SetActive(false);
            Pop(_menuParent);
        }
    }

    void Pop(GameObject gameObject)
    {
        popTween = gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), _popDuration)
        .SetEase(Ease.Flash)
        .OnComplete(() => {
            gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), _popDuration);
        });
    }

}
