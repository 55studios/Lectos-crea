using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
public class PalabraGeneradoraAnimationsIn : MonoBehaviour
{
    public Animator Ball;
    [Header("Botones")]
    public ScaleAnimationInOut StartButton;
    public ScaleAnimationInOut Palabra;
    public ScaleAnimationInOut Reset;
    public ScaleAnimationInOut Next;
    public ScaleAnimationInOut Back;
    public ScaleAnimationInOut End;

    [Header("Palabra generadora")]
    public Image[] _SilabasMarcos;
    public AudioSource audioSource;
    public UnityEvent[] _EndStepEvent;
    public AudioClip[] clipAudio;
    public float Duration = 5;
    public Ease Interpolation = Ease.OutCirc;
    public float DelayStart;
    public float DelaySequence;
    public float DelayOncomplete;
    public UnityEvent Oncomplete;

    [Header("Botones")]
    public ScaleAnimationInOut imagenPalabra;
    public UnityEvent EventImagenPalabra;

    private void OnEnable() {
        imagenPalabra.OutAnimation();
        End.OutAnimation();
        Back.OutAnimation();
        StartButton.InAnimation();
        Palabra.InAnimation();
    }

    public void SequenceAnimationText(){
        StartCoroutine(SequencerDelay());
    }

    public void SecuenceAnimationNext() {
        StartCoroutine(SequenceImageDelay());
    }

    IEnumerator SequencerDelay() {
        imagenPalabra.OutAnimation();
        Palabra.InAnimation();
        for (int i = 0; i < _SilabasMarcos.Length; i++) {
            var TempColor = _SilabasMarcos[i].color;
            TempColor.a = 0;
            _SilabasMarcos[i].color = TempColor;
            Debug.Log(i);
        }
        Ball.SetTrigger("StartAnimation");
        yield return new WaitForSeconds(DelayStart);
        for (int i = 0; i < _SilabasMarcos.Length; i++) {
            _SilabasMarcos[i].DOFade(255, Duration).SetEase(Interpolation).OnComplete(() => _EndStepEvent[i].Invoke());
            audioSource.clip = clipAudio[i];
            audioSource.Play();
            yield return new WaitForSeconds(DelayStart);
            Debug.Log("Ends every tween");
        }
        yield return new WaitForSeconds(DelayOncomplete);
        Reset.InAnimation();
        Next.InAnimation();
        Oncomplete.Invoke();
    }

    IEnumerator SequenceImageDelay() {
        for (int i = 0; i < _SilabasMarcos.Length; i++) {
            var TempColor = _SilabasMarcos[i].color;
            TempColor.a = 0;
            _SilabasMarcos[i].color = TempColor;
            Debug.Log(i);
        }
        Palabra.OutAnimation();
        yield return new WaitForSeconds(DelayStart);
        imagenPalabra.InAnimation();
        EventImagenPalabra.Invoke();
        yield return new WaitForSeconds(DelaySequence);
        Back.InAnimation();
        End.InAnimation();

    }
}
