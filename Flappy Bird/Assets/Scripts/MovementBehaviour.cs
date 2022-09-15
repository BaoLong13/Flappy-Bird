using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] Transform mTransform;

    void Start()
    {
        mTransform.DOMoveY(1f, 2, false).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
}
