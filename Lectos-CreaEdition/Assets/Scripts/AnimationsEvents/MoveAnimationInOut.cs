using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAnimationInOut : MonoBehaviour
{
    public bool onStartAnimation;
    public float startInDelay = 0;
    public float delay = 1;
    public Ease easeIn = Ease.InOutQuad;
    public Vector2 moveTo;

    public float startOutDelay = 1;
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
        StartCoroutine(InAnim());
    }

    public void OutAnimation() {
        StartCoroutine(OutAnim());
    }

    IEnumerator InAnim() {
        yield return new WaitForSeconds(startInDelay);
        mainTransform.DOAnchorPos(moveTo, delay).SetEase(easeIn);
    }

    IEnumerator OutAnim() {
        yield return new WaitForSeconds(startOutDelay);
        mainTransform.DOAnchorPos(moveFrom, delay).SetEase(easeIn);
    }
}
