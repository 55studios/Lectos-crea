 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationLecto : MonoBehaviour
{
    public bool onStartAnimation;
    public float startInDelay = 0;
    public float startOutDelay = 1;
    public float delay = 1;
    public bool UseSecuence = false;

    public Ease easeInStart = Ease.InOutExpo;
    public Vector2 moveToStart;

    public Ease easeTo = Ease.InOutExpo;
    public Vector2 moveTo;

    public Ease easeFrom = Ease.InOutExpo;
    public Vector2 moveFrom;

    public Ease easeToSecuence = Ease.InOutExpo;
    public Vector2 moveToSecuence;

    public Ease easeFromSecuence = Ease.InOutExpo;
    public Vector2 moveFromSecuence;

    public Ease easeToSecuenceFinal = Ease.InOutExpo;
    public Vector2 moveToSecuenceFinal;

    public Ease easeFromSecuenceFinal = Ease.InOutExpo;
    public Vector2 moveFromSecuenceFinal;

    private Transform mainTransform;


    private void Start() {
        mainTransform = this.gameObject.GetComponent<Transform>();
        if (onStartAnimation) {
            mainTransform.DOLocalMove(moveToStart, delay).SetEase(easeInStart).OnComplete(() => { Debug.Log("Animation is end");});
        }
    }

    public void InAnimation() {
        StartCoroutine(InAnim());
    }

    public void OutAnimation() {
        StartCoroutine(OutAnim());
    }
    IEnumerator InAnim() {
        if (!UseSecuence) {
            yield return new WaitForSeconds(startInDelay);
            mainTransform.DOLocalMove(moveTo, delay).SetEase(easeTo);
        }
        else {
            yield return new WaitForSeconds(startInDelay);
            mainTransform.DOLocalMove(moveTo, delay).SetEase(easeTo).OnComplete(() => {
                mainTransform.DOLocalMove(moveToSecuence, delay).SetEase(easeToSecuence).OnComplete(() => {
                    mainTransform.DOLocalMove(moveToSecuenceFinal, delay).SetEase(easeToSecuenceFinal);
                });
            });
        }
    }

    IEnumerator OutAnim() {
        if (!UseSecuence) {
            yield return new WaitForSeconds(startOutDelay);
            mainTransform.DOLocalMove(moveFrom, delay).SetEase(easeFrom);
        }
        else {
            yield return new WaitForSeconds(startOutDelay);
            mainTransform.DOLocalMove(moveFrom, delay).SetEase(easeFrom).OnComplete(() => {
                mainTransform.DOLocalMove(moveFromSecuence, delay).SetEase(easeFromSecuence).OnComplete(() => {
                    mainTransform.DOLocalMove(moveFromSecuenceFinal, delay).SetEase(easeFromSecuenceFinal);
                });
            });
        }
    }

    IEnumerator StartAnim(float delay) {
        yield return new WaitForSeconds(delay);
    }
}
