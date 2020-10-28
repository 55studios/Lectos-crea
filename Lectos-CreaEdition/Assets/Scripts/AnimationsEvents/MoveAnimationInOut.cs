using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAnimationInOut : MonoBehaviour
{
    public bool onStartAnimation;
    public float delay = 1;
    public Ease easeIn = Ease.InOutQuad;
    public Vector2 moveTo;
    public Ease easeOut;
    public Vector2 moveFrom;

    private RectTransform mainTransform;


    private void Start() {
        mainTransform = this.gameObject.GetComponent<RectTransform>();
        if (onStartAnimation) {
            mainTransform.DOAnchorPos(moveTo, delay).SetEase(easeIn);
        }
    }

    public void InAnimation() {

        mainTransform.DOAnchorPos(moveTo, delay).SetEase(easeIn);
    }

    public void OutAnimation() {

        mainTransform.DOAnchorPos(moveFrom, delay).SetEase(easeIn);
    }
}
