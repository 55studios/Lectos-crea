using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedButton : MonoBehaviour {

    public int ButtonTutorial;
    public GameObject arrow;
    public float timeForActivation;
    public AudioSource boingSound;
    public UnityEvent clickEvent;

    private DialogTrigger dialogueT;
    private Animator anim;
    private SphereCollider sphereColl;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start ()
    {
        dialogueT = GetComponent<DialogTrigger>();
        anim = GetComponent<Animator>();
        sphereColl = GetComponent<SphereCollider>();

        arrow.SetActive(false);
        sphereColl.enabled = false;

        if (ButtonTutorial == 1)
        {
            if (gameManager.enableTutorial[0] == true)
            {
                Invoke("TimeOfInit", timeForActivation);
            }
        }
        if (ButtonTutorial == 2)
        {
            if (gameManager.enableTutorial[1] == true)
            {
                Invoke("TimeOfInit", timeForActivation);
            }
        }
    }

    private void OnMouseDown()
    {
        arrow.SetActive(false);
        anim.SetTrigger("IsPressed");
        dialogueT.TriggerDialogue();
        sphereColl.enabled = false;
        boingSound.Play();
        clickEvent.Invoke();

        if (ButtonTutorial == 1)
        {
            gameManager.enableTutorial[0] = false;
        }
        if (ButtonTutorial == 2)
        {
            gameManager.enableTutorial[1] = false;
        }
    }

    void TimeOfInit()
    {
        arrow.SetActive(true);
        sphereColl.enabled = true;
        anim.SetTrigger("ToIdle");
    }
}
