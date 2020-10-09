using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator anim;
    public AudioSource escrituraSound;
    //public bool actionPostText;

    private Queue<string> Sentences;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start ()
    {
        Sentences = new Queue<string>();
        //actionPostText = false;
		
	}

    public void startDialogue(Dialog dialogue)
    {
        anim.SetBool("IsOpen", true);
        Debug.Log("starting conversation with" + dialogue.name);
        nameText.text = dialogue.name;
        Sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
            escrituraSound.Play();
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            escrituraSound.Stop();
            EndDialog();
            return;
        }

        string sentence = Sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence));
        //escrituraSound.Stop();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            //escrituraSound.Play();
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        escrituraSound.Stop();
        nameText.text = "";
        dialogueText.text = "";
        anim.SetBool("IsOpen", false);
        //actionPostText = true;
        string LevelName = Application.loadedLevelName;
        if (!gameManager.enableLevels[0] && LevelName == "MainMenu")
        {
            gameManager.enableLevels[0] = true;
        }
        if (!gameManager.subEnableLevels[0] && LevelName == "Planeta_1")
        {
            gameManager.subEnableLevels[0] = true;
        }
    }
}
