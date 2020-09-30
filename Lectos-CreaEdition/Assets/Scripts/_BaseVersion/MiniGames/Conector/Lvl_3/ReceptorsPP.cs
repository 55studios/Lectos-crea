using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceptorsPP : MonoBehaviour {

    [HideInInspector]
    public int id;
    public Sprite spriteWin;
    public GameObject frame;
    public GameObject stars;
    public float waitToDestroy = 1;
    public Animator ReceptorCharacter;
    public int answer;

    private AudioSource SoundAcert;
    private SpriteRenderer sprite;
    private ConectManagerPP conectorManager;
    private bool abaliable;
    private SelectionAndPlaySound fxSound;
    private CheckAnswer3 ca;

    void Start()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer3>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectManagerPP>();
        fxSound = GameObject.Find("FXSounds").GetComponent<SelectionAndPlaySound>();
        SoundAcert = GameObject.Find("AcertSound").GetComponent<AudioSource>();
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
        if (collision.gameObject.GetComponent<ActivatorsPP>().id == id && !collision.gameObject.GetComponent<ActivatorsPP>().dragging)
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
            ReceptorCharacter.gameObject.SetActive(true);
            ReceptorCharacter.SetTrigger("Start");
            conectorManager.ProgressShip();
            StartCoroutine(WaitAfterDie());
            SoundAcert.Play();
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
        ca.re = transform.GetComponent<ReceptorsPP>();
    }

    private void OnMouseExit()
    {
        ca.answer = -1;
    }

    IEnumerator WaitAfterDie()
    {
        yield return new WaitForSeconds(waitToDestroy);
        if (conectorManager.count <= conectorManager.SpwanActivators.Length - 2)
        {
            conectorManager.LoadNextReceptor();
        }
        Destroy(transform.parent.gameObject);
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
        ReceptorCharacter.gameObject.SetActive(true);
        ReceptorCharacter.SetTrigger("Start");
        conectorManager.ProgressShip();
        StartCoroutine(WaitAfterDie());
        SoundAcert.Play();
        fxSound.numberCLip = id;
        fxSound.SelectSoundAndPlay();
    }
}

