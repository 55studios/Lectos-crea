using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptorsTrain : MonoBehaviour {

    [HideInInspector]
    public int id;
    public Sprite spriteWin;
    public GameObject frame;
    public GameObject stars;
    public int answer;

    private AudioSource trainSound_;
    private SpriteRenderer sprite;
    private ConectorManagerTrain conectorManager;
    private bool abaliable;
    private Animator train;
    private AudioSource correct;
    private SelectionAndPlaySound fxSound;
    private CheckAnswer2 ca;

    void Start()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer2>();
        trainSound_ = GameObject.Find("SoundTrain").GetComponent<AudioSource>();
        train = GameObject.Find("Tren").GetComponent<Animator>();
        fxSound = GameObject.Find("FXSounds").GetComponent<SelectionAndPlaySound>();
        correct = GameObject.Find("AcertSound").GetComponent <AudioSource>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManagerTrain>();
        sprite = gameObject.GetComponentInParent(typeof(SpriteRenderer)) as SpriteRenderer;
        frame.SetActive(false);
        abaliable = true;

    }

    private void Update()
    {
        if (conectorManager.CountDown == 0 || conectorManager.correctAnswers.GameWin)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (abaliable)
        {
            frame.SetActive(true);
        }


    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActivatorsTrain>().id 
            == id && !collision.gameObject.GetComponent<ActivatorsTrain>().dragging)
        {
            if (id == 0)
            {
                conectorManager.correctAnswers.Answer_1 = true;
            }
            else if (id == 1)
            {
                conectorManager.correctAnswers.Answer_2 = true;
            }
            else if (id == 2)
            {
                conectorManager.correctAnswers.Answer_3 = true;
            }
            else if (id == 3)
            {
                conectorManager.correctAnswers.Answer_4 = true;
            }
            else if (id == 4)
            {
                conectorManager.correctAnswers.Answer_5 = true;
            }
            sprite.sprite = spriteWin;
            Instantiate(stars, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            abaliable = false;
            frame.SetActive(true);
            trainSound_.Play();
            train.SetTrigger("Next");
            conectorManager.ProgressShip();
            correct.Play();
            fxSound.numberCLip = id;
            fxSound.SelectSoundAndPlay();
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (abaliable)
        {
            frame.SetActive(false);
        }

    }

    private void OnMouseEnter()
    {
        ca.answer = answer;
        ca.re = transform.GetComponent<ReceptorsTrain>();
    }

    private void OnMouseExit()
    {
        ca.answer = -1;
    }

    public void compareAnswers(int i)
    {
            if (id == 0)
            {
                conectorManager.correctAnswers.Answer_1 = true;
            }
            else if (id == 1)
            {
                conectorManager.correctAnswers.Answer_2 = true;
            }
            else if (id == 2)
            {
                conectorManager.correctAnswers.Answer_3 = true;
            }
            else if (id == 3)
            {
                conectorManager.correctAnswers.Answer_4 = true;
            }
            else if (id == 4)
            {
                conectorManager.correctAnswers.Answer_5 = true;
            }
            sprite.sprite = spriteWin;
            Instantiate(stars, transform.position, Quaternion.identity);
            //Destroy(collision.gameObject);
            abaliable = false;
            frame.SetActive(true);
            trainSound_.Play();
            train.SetTrigger("Next");
            conectorManager.ProgressShip();
            correct.Play();
            fxSound.numberCLip = id;
            fxSound.SelectSoundAndPlay();
    }
}

