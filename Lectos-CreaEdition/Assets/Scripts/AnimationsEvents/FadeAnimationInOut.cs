using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FadeAnimationInOut : MonoBehaviour
{
    public bool isUi;
    public float waitforAwake = 0;
    public bool onStartAnimation;
    public float waitForInit = 1;
    public float waitForOut = 0;
    public float delayIn = 1;
    public Ease easeIn = Ease.InOutQuad;
    public float moveTo;
    public float delayOut = 0.5f;
    public Ease easeOut = Ease.InOutQuad;
    public float moveFrom;

    private Transform _mainTransform;
    private SpriteRenderer mainTransform;

    void Start() {
        mainTransform = GetComponent<SpriteRenderer>();
        DOTween.Init(true, true, LogBehaviour.Verbose);
        StartCoroutine(AwakeAnimation());
    }

    public void InAnimation() {
        StartCoroutine(StartAnim());
    }

    public void OutAnimation() {
        StartCoroutine(EndAnim());
    }

    IEnumerator StartAnim() {
        yield return new WaitForSeconds(waitForInit);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<SpriteRenderer>();
            mainTransform.DOFade(moveTo, delayIn).SetEase(easeIn);
        }
        else {
            //_mainTransform = this.gameObject.GetComponent<Transform>();
            //_mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
        }
    }

    IEnumerator EndAnim() {
        yield return new WaitForSeconds(waitForOut);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<SpriteRenderer>();
            mainTransform.DOFade(moveFrom, delayOut).SetEase(easeOut);
        }
        else {
            //_mainTransform = this.gameObject.GetComponent<Transform>();
            //_mainTransform.DOScale(moveFrom, delayOut).SetEase(easeOut);
        }
    }
    IEnumerator AwakeAnimation() {
        yield return new WaitForSeconds(waitforAwake);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<SpriteRenderer>();
            if (onStartAnimation) {
                mainTransform.DOFade(moveTo, delayIn).SetEase(easeIn);
            }
        }
        else {
            //_mainTransform = this.gameObject.GetComponent<Transform>();
            //if (onStartAnimation) {
               // _mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
            }
        }
    //}

    private void OnDisable() {
        DOTween.ClearCachedTweens();

    }
}
