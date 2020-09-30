using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorsRC : MonoBehaviour {

    [HideInInspector]
    public int id;
    public Sprite spriteWin;
    public GameObject frame;
    public GameObject stars;
    public int answer;

    private SpriteRenderer sprite;
    private ConectorManagerRC conectorManager;
    private AudioSource correct;
    private bool abaliable;
    private CheckAnswer13 ca;

    void Start()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer13>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManagerRC>();
        correct = GameObject.Find("AcertSound").GetComponent<AudioSource>();
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
        if (collision.gameObject.GetComponent<ActivatorsRC>().id == id && !collision.gameObject.GetComponent<ActivatorsRC>().dragging)
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
            else if (id == 5)
            {
                conectorManager.correctAnswers.Answer_6 = true;
            }
            sprite.sprite = spriteWin;
            Instantiate(stars, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            abaliable = false;
            frame.SetActive(true);
            correct.Play();
            conectorManager.ProgressShip();

        }
    }*/

    private void OnMouseEnter()
    {
        ca.answer = answer;
        ca.re = transform.GetComponent<ReceptorsRC>();
    }

    private void OnMouseExit()
    {
        ca.answer = -1;
    }

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
        else if (id == 4)
        {
            conectorManager.correctAnswers.Answer_5 = true;
        }
        else if (id == 5)
        {
            conectorManager.correctAnswers.Answer_6 = true;
        }
        sprite.sprite = spriteWin;
        Instantiate(stars, transform.position, Quaternion.identity);
        //Destroy(collision.gameObject);
        abaliable = false;
        frame.SetActive(true);
        correct.Play();
        conectorManager.ProgressShip();
    }
}
