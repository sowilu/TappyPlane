using UnityEngine;
using DG.Tweening;

public class PulseAnimator : MonoBehaviour
{
    public float scale = 1.3f;
    public float duration = 0.5f;
    public Ease ease = Ease.OutQuad;
    
    void Start()
    {
        transform.DOScale(scale, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }

    
}
