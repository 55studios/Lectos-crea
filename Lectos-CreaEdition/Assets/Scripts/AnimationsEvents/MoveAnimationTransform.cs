using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveAnimationTransform : MonoBehaviour
{
    [Header("lecto")]
    public AnimationLecto Lecto;
    public AnimationLecto Lectina;

    [Header("Principal Screen")]
    public ManagerAnimations StartAnimationUi;

    [Header("Trophy Screen")]
    public MoveAnimationTransformInOut door_1;
    public MoveAnimationTransformInOut door_2;
    public GameObject canvasTrophy;

    [Header("UI")]
    public Button RigthButton;
    public Button LeftButton;

    [Header("Time Animation")]
    public bool onStartAnimation;
    public float startInDelay = 0;
    public float delay = 1;
    public Vector2 origin;
    public Ease easeIn = Ease.InOutQuad;
    public Vector2 moveTo;
    public UnityEvent OnCOmpleteStart;
    public float startOutDelay = 1;
    public Ease easeOut;
    public Vector2 moveFrom;

    private Transform mainTransform;
    [Range(-1,1)]
    private int actualPosition = 0;
    //private Animator lectoAnimator;
    //private Animator lectinaAnimator;

    private void Start() {
        actualPosition = 0;
        mainTransform = this.gameObject.GetComponent<Transform>();
        //lectoAnimator = Lecto.transform.GetComponent<Animator>();
        //lectinaAnimator = Lecto.transform.GetComponent<Animator>();
        canvasTrophy.SetActive(false);
        if (onStartAnimation) {
            mainTransform.DOMove(moveTo, delay).SetEase(easeIn).OnComplete(() => { StartCoroutine(StartAnim(1));});
        }
    }

    public void RigthAnimation() {
        if (actualPosition <= 0) {
            RigthButton.interactable = false;
            LeftButton.interactable = false;
            if (actualPosition == 0) {
                door_1.InAnimation();
                door_2.InAnimation();
            }
            StartCoroutine(InAnim());
        }  
    }

    public void LeftAnimation() {
        if (actualPosition >=0) {
            RigthButton.interactable = false;
            LeftButton.interactable = false;
            door_1.OutAnimation();
            door_2.OutAnimation();
            StartCoroutine(OutAnim());
        }  
    }

    IEnumerator InAnim() {
        if (actualPosition == 0) {
            Lectina.OutAnimation();
            yield return new WaitForSeconds(startInDelay);
            //Lecto.transform.DOMove(moveFrom, delay).SetEase(easeIn);
            mainTransform.DOMove(moveTo, delay).SetEase(easeIn).OnComplete(() => {
                StartAnimationUi.OnAnimationOut();
                canvasTrophy.SetActive(true);
                RigthButton.interactable = true;
                LeftButton.interactable = false;
            });

        } else if (actualPosition == -1) {
            Lecto.InAnimation();
            mainTransform.DOMove(origin, delay).SetEase(easeIn).OnComplete(() => {
                StartAnimationUi.OnAnimationIn();
                canvasTrophy.SetActive(false);
                RigthButton.interactable = true;
                LeftButton.interactable = true;
            });
        }
        actualPosition++;
    }

    IEnumerator OutAnim() {
        if (actualPosition == 0) {
            Lecto.OutAnimation();
            yield return new WaitForSeconds(startOutDelay);
            mainTransform.DOMove(moveFrom, delay).SetEase(easeIn).OnComplete(() => {
                canvasTrophy.SetActive(false);
                StartAnimationUi.OnAnimationOut();
                RigthButton.interactable = false;
                LeftButton.interactable = true;
            });
        }
        else if (actualPosition == 1) {
            Lectina.InAnimation();
            yield return new WaitForSeconds(startOutDelay);
            mainTransform.DOMove(origin, delay).SetEase(easeIn).OnComplete(() => {
                StartAnimationUi.OnAnimationIn();
                RigthButton.interactable = true;
                LeftButton.interactable = true;
            });
            yield return new WaitForSeconds(1);
            canvasTrophy.SetActive(false);
        }
        actualPosition--;
    }

    IEnumerator StartAnim(float delay) {
        yield return new WaitForSeconds(delay);
        OnCOmpleteStart.Invoke();
    }

}