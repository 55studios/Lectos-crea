using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LectoTutorialEventButton : MonoBehaviour{

    public Button buttonLectinaTuto;
    public AudioClip introLectina;
    public AudioClip lectinaTuto;
    public AudioClip lectinaTutoTrofeo;
    public AudioClip lectinaTutoTienda;
    public float waitForStart = 0;
    public float waitForEvent = 0;
    public UnityEvent Onstart;
    public UnityEvent OnEndAudio;
    private AudioSource m_Audio;
    private MoveAnimationTransform m_control;
    private float m_DurationCLip;

    private void Start() {
        m_Audio = GetComponent<AudioSource>();
        m_control = GameObject.Find("Ship").GetComponent<MoveAnimationTransform>();
        PlayerPrefs.SetInt("IntroTutorial",0);
        if (PlayerPrefs.GetInt("IntroTutorial") == 0) {
            buttonLectinaTuto.interactable = false;
            m_Audio.clip = introLectina;
            m_DurationCLip = m_Audio.clip.length;
            StartCoroutine(DurationClip());
            m_Audio.Play();
        }
    }

    public void TutorialLectina() {
        StartCoroutine(LectinaT());
    }

    IEnumerator LectinaT() {
        if (m_control.actualPosition == 0) {
            yield return new WaitForSeconds(waitForStart);
            m_Audio.clip = lectinaTuto;
            m_DurationCLip = m_Audio.clip.length;
            StartCoroutine(DurationClip());
            m_Audio.Play();
            yield return new WaitForSeconds(waitForEvent);
            Onstart.Invoke();
        } else if (m_control.actualPosition == 1) {
            yield return new WaitForSeconds(waitForStart);
            m_Audio.clip = lectinaTutoTrofeo;
            m_DurationCLip = m_Audio.clip.length;
            StartCoroutine(DurationClip());
            m_Audio.Play();
        }
        else if (m_control.actualPosition == -1) {
            m_Audio.clip = lectinaTutoTienda;
            m_DurationCLip = m_Audio.clip.length;
            StartCoroutine(DurationClip());
            m_Audio.Play();
        }
    }
    IEnumerator DurationClip() {
        yield return new WaitForSeconds(m_DurationCLip);
        OnEndAudio.Invoke();
    }
}
