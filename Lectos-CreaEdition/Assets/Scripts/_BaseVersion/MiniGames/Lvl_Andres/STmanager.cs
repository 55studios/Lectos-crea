using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class STmanager : MonoBehaviour {

    public ConnectorManagerSound cms;
    public STpoint[] points;
    public int index;
    string[] originalAnswers = new string[5]; 
    AudioSource As;
    int count;
    bool check = false;
    public GameObject leckticia;

	// Use this for initialization
	void Start () {
        As = GetComponent<AudioSource>();
        index = 0;
        int i = 0;
        foreach (string it in originalAnswers) 
            {
            originalAnswers[i] = points[i].word.text;
            i++;
        }
    }

    public void CheckAnswer() {
        if (check) {
            if (EventSystem.current.currentSelectedGameObject.name == points[index].gameObject.name)
            {
                check = false;
                points[index].picture.gameObject.transform.GetComponent<Image>().enabled = true;
                points[index].word.text = "";
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                switch (index)
                {
                    case 0:
                        As.clip = points[index].correctAnswer;
                        As.Play();
                        cms.correctAnswers.Answer_1 = true;
                        cms.ProgressShip();
                        break;
                    case 1:
                        As.clip = points[index].correctAnswer;
                        As.Play();
                        cms.correctAnswers.Answer_2 = true;
                        cms.ProgressShip();
                        break;
                    case 2:
                        As.clip = points[index].correctAnswer;
                        As.Play();
                        cms.correctAnswers.Answer_3 = true;
                        cms.ProgressShip();
                        break;
                    case 3:
                        As.clip = points[index].correctAnswer;
                        As.Play();
                        cms.correctAnswers.Answer_4 = true;
                        cms.ProgressShip();
                        break;
                    case 4:
                        As.clip = points[index].correctAnswer;
                        As.Play();
                        cms.correctAnswers.Answer_5 = true;
                        cms.ProgressShip();
                        break;
                    default:

                        break;
                }
                if (index < 4)
                {
                    index++;
                }
            } 
            
        }
    }

    public void playAudio(Animator anim) {
        check = true;
        As.clip = points[index].sound;
        As.Play();
        anim.SetTrigger("playSound");
        if (leckticia != null) {
            leckticia.GetComponent<Animator>().SetTrigger("reaction");
        }
    }

    public void ResetAnswers() {

        count = 0;
        int i = 0;
        check = false;
        foreach (STpoint item in points) {
            points[i].word.text = originalAnswers[i];
            i++;
        }
    }
}
