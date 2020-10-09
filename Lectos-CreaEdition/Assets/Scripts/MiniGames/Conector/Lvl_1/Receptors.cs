using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receptors : MonoBehaviour {

    #region publics
    [HideInInspector]
    public int id;
    public Sprite spriteWin;
    public GameObject frame;
    public GameObject stars;
    public int answer;
    #endregion

    #region privates
    private SpriteRenderer sprite;
    private ConectorManager conectorManager;
    private bool abaliable;
    private AudioSource SoundAcert;
    private SelectionAndPlaySound fxSound;
    private CheckAnswer ca;
    #endregion

    void Start ()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManager>();
        fxSound = GameObject.Find("FXSounds").GetComponent<SelectionAndPlaySound>();
        sprite = gameObject.GetComponentInParent(typeof(SpriteRenderer)) as SpriteRenderer;
        frame.SetActive(false);
        abaliable = true;
        SoundAcert = GameObject.Find("AcertSound").GetComponent<AudioSource>();
 
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
        if (collision.gameObject.GetComponent<Activators>().id == id && !collision.gameObject.GetComponent<Activators>().dragging)
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

    private void OnMouseEnter()
    {
        ca.answer = answer;
        ca.re = transform.GetComponent<Receptors>();
    }

    private void OnMouseExit()
    {
        ca.answer = -1;
    }

    public void compareAnswers(int i) {
        if (i == 0)
        {
            conectorManager.correctAnswers.Answer_1 = true;
        }
        else if (i == 1)
        {
            conectorManager.correctAnswers.Answer_2 = true;
        }
        else if (i == 2)
        {
            conectorManager.correctAnswers.Answer_3 = true;
        }
        else if (i == 3)
        {
            conectorManager.correctAnswers.Answer_4 = true;
        }
        else if (i == 4)
        {
            conectorManager.correctAnswers.Answer_5 = true;
        }

        sprite.sprite = spriteWin;
        Instantiate(stars, transform.position, Quaternion.identity);
        //Destroy(collision.gameObject);
        abaliable = false;
        frame.SetActive(true);
        SoundAcert.Play();
        fxSound.numberCLip = id;
        fxSound.SelectSoundAndPlay();
        conectorManager.ProgressShip();
    }
}
