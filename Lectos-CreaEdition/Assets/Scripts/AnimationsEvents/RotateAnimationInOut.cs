using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateAnimationInOut : MonoBehaviour
{
    public bool isUi;
    public float waitforAwake = 0;
    public bool onStartAnimation;
    public float waitForInit = 1;
    public float waitForOut = 0;
    public float delayIn = 1;
    public Ease easeIn = Ease.InOutQuad;
    public Vector3 moveTo;
    public float delayOut = 0.5f;
    public Ease easeOut = Ease.InOutQuad;
    public Vector3 moveFrom;

    private Transform _mainTransform;
    private RectTransform mainTransform;

    void Start() {
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
            mainTransform = this.gameObject.GetComponent<RectTransform>();
            mainTransform.DORotate(moveTo, delayIn).SetEase(easeIn);
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
            _mainTransform.DORotate(moveTo, delayIn).SetEase(easeIn);
        }
    }

    IEnumerator EndAnim() {
        yield return new WaitForSeconds(waitForOut);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<RectTransform>();
            mainTransform.DORotate(moveFrom, delayOut).SetEase(easeOut);
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
            _mainTransform.DORotate(moveFrom, delayOut).SetEase(easeOut);
        }
    }

    IEnumerator AwakeAnimation() {
        yield return new WaitForSeconds(waitforAwake);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<RectTransform>();
            if (onStartAnimation) {
                mainTransform.DORotate(moveTo, delayIn).SetEase(easeIn);
            }
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
            if (onStartAnimation) {
                _mainTransform.DORotate(moveTo, delayIn).SetEase(easeIn);
            }
        }
    }


    private void OnDisable() {
        DOTween.ClearCachedTweens();
    }
}
