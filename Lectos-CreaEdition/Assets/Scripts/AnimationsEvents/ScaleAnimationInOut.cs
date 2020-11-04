using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimationInOut : MonoBehaviour {

    public bool isUi;
    public float waitforAwake = 0;
    public bool onStartAnimation;
    public float waitForInit = 1;
    public float delayIn = 1;
    public Ease easeIn = Ease.InOutQuad;
    public Vector3 moveTo;
    public float delayOut = 0.5f;
    public Ease easeOut = Ease.InOutQuad;
    public Vector3 moveFrom;

    private Transform _mainTransform;
    private RectTransform mainTransform;

    void Start() {
        StartCoroutine(AwakeAnimation());
    }

    public void InAnimation() {
        StartCoroutine(StartAnim());
    }

    public void OutAnimation() {
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<RectTransform>();
                mainTransform.DOScale(moveFrom, delayOut).SetEase(easeOut);
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
                _mainTransform.DOScale(moveFrom, delayOut).SetEase(easeOut);
        }
    }

    IEnumerator StartAnim() {
        yield return new WaitForSeconds(waitForInit);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<RectTransform>();
            if (onStartAnimation) {
                mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
            }
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
            if (onStartAnimation) {
                _mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
            }
        }
    }

    IEnumerator AwakeAnimation() {
        yield return new WaitForSeconds(waitforAwake);
        if (isUi) {
            mainTransform = this.gameObject.GetComponent<RectTransform>();
            if (onStartAnimation) {
                mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
            }
        }
        else {
            _mainTransform = this.gameObject.GetComponent<Transform>();
            if (onStartAnimation) {
                _mainTransform.DOScale(moveTo, delayIn).SetEase(easeIn);
            }
        }
    }
}
