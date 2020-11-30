using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class MoveAnimationTransformInOut : MonoBehaviour
{
    public bool onStartAnimation;
    public float startInDelay = 0;
    public float delay = 1;
    public Ease easeIn = Ease.InOutQuad;
    public Vector2 moveTo;
    public UnityEvent OnCompleteStart;
    public float startOutDelay = 1;
    public Ease easeOut;
    public Vector2 moveFrom;

    private Transform mainTransform;


    private void Start() {
        mainTransform = this.gameObject.GetComponent<Transform>();
        if (onStartAnimation) {
            //mainTransform.DOLocalMove(moveTo, delay).SetEase(easeIn).OnComplete(() => { StartCoroutine(StartAnim(1)); });
            StartCoroutine(InAnim());
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
        mainTransform.DOLocalMove(moveTo, delay).SetEase(easeIn);
    }

    IEnumerator OutAnim() {
        yield return new WaitForSeconds(startOutDelay);
        mainTransform.DOLocalMove(moveFrom, delay).SetEase(easeIn);
    }

    IEnumerator StartAnim(float delay) {
        yield return new WaitForSeconds(delay);
        OnCompleteStart.Invoke();
    }
}

