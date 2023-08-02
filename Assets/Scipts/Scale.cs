using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    private Vector3 mainScale;
    private Vector3 newScale;
    void Start()
    {
        mainScale = transform.localScale;
        newScale = mainScale * 2;
        OnScale();
    }

    private void OnScale()
    {
        transform.DOScale(newScale, 1.0f).SetEase(Ease.InOutSine).OnComplete(() => { transform.DOScale(mainScale, 1.0f).SetEase(Ease.OutBounce).SetDelay(0.5f).OnComplete(OnScale); });

    }
}

