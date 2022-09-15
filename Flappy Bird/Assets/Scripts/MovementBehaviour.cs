using UnityEngine;
using DG.Tweening;

public class MovementBehaviour : MonoBehaviour
{
    [SerializeField] Transform mTransform;

    void Start()
    {
        mTransform.DOMoveY(1f, 1, false).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
}
