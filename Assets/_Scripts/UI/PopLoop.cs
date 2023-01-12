using UnityEngine;
using DG.Tweening;

public class PopLoop : MonoBehaviour
{

    [SerializeField] private int _duration;

    void Start()
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), _duration).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }

    
}
