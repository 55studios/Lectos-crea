using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LectoTutorialEventButton : MonoBehaviour{

    public AudioClip introLectina;
    public AudioClip lectinaIntro;
    public float waitForStart = 0;
    public float waitForEvent = 0;
    public UnityEvent Onstart;
    private AudioSource m_Audio;
    private MoveAnimationTransform m_control;

    private void Start() {
        m_Audio = GetComponent<AudioSource>();
        m_control = GameObject.Find("Ship").GetComponent<MoveAnimationTransform>();
        PlayerPrefs.SetInt("IntroTutorial",0);
        if (PlayerPrefs.GetInt("IntroTutorial") == 0) {
            m_Audio.clip = introLectina;
            m_Audio.Play();
        }
    }

    public void TutorialLectina() {
        StartCoroutine(LectinaT());
    }

    IEnumerator LectinaT() {
        if (m_control.actualPosition == 0) {
            yield return new WaitForSeconds(waitForStart);
            m_Audio.clip = lectinaIntro;
            m_Audio.Play();
            yield return new WaitForSeconds(waitForEvent);
            Onstart.Invoke();
        } else if (m_control.actualPosition == 1) {
            print("Tutoriale trofeos");
        }
        else if (m_control.actualPosition == -1) {
            print("Tutorial Tienda");
        }
    }
}
