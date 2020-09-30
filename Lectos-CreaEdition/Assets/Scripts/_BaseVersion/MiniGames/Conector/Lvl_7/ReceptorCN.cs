using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorCN : MonoBehaviour {
    [HideInInspector]
    public int id;
    public Sprite spriteWin;
    public GameObject frame;
    public GameObject stars;
    public int answer;

    private SpriteRenderer sprite;
    private ConectorManagerCN conectorManager;
    private bool abaliable;
    private Animator train;
    private SelectionAndPlaySound fxSound;
    private AudioSource SoundAcert;
    private CheckAnswer7 ca;

    void Start()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer7>();
        train = GameObject.Find("Tren").GetComponent<Animator>();
        fxSound = GameObject.Find("FXSounds").GetComponent<SelectionAndPlaySound>();
        SoundAcert = GameObject.Find("AcertSound").GetComponent<AudioSource>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManagerCN>();
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

    private void OnMouseEnter()
    {
        ca.answer = answer;
        ca.re = transform.GetComponent<ReceptorCN>();
    }

    private void OnMouseExit()
    {
        ca.answer = -1;
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ActivatorsCN>().id
            == id && !collision.gameObject.GetComponent<ActivatorsCN>().dragging)
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

            sprite.sprite = spriteWin;
            Instantiate(stars, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            abaliable = false;
            frame.SetActive(true);
            train.SetTrigger("Next");
            SoundAcert.Play();
            fxSound.numberCLip = id;
            fxSound.SelectSoundAndPlay();
            conectorManager.ProgressShip();
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (abaliable)
        {
            frame.SetActive(false);
        }

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

        sprite.sprite = spriteWin;
        Instantiate(stars, transform.position, Quaternion.identity);
        //Destroy(collision.gameObject);
        abaliable = false;
        frame.SetActive(true);
        train.SetTrigger("Next");
        SoundAcert.Play();
        fxSound.numberCLip = id;
        fxSound.SelectSoundAndPlay();
        conectorManager.ProgressShip();
    }
}
