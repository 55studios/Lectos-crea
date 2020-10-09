using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {
    
    #region publics
    public Text t;
    public DisplayImages di;
    public ParticleSystem fx;
    #endregion

    #region privates
    string imageName;
    int score;
    private TextManager managerText;
    bool checkText = true;
    private AudioSource acertSound;
    bool HelpEnabled = false;
    int mistakes = 0;
    bool canWrite = true;
    AudioSource diSource;
    #endregion

    void Start()
    {
        t.text = "";
        imageName = di.CurrentImage();
        managerText = GameObject.Find("ConectorGenerator").GetComponent<TextManager>();
        acertSound = GameObject.Find("AcertSound").GetComponent<AudioSource>();
        diSource = di.gameObject.GetComponent<AudioSource>();
        score = 1;
    }

    void Update()
    {

        foreach (char c in Input.inputString)
        {
            if (canWrite) { 
            if (c == '\b') // al apachurrar delete borra 
            {
                if (t.text.Length != 0 && !HelpEnabled)
                {
                    t.text = t.text.Substring(0, t.text.Length - 1);
                } else if (t.text.Length != 1)
                {
                    t.text = t.text.Substring(0, t.text.Length - 1);
                }
            }
            /*else if ((c == '\n') || (c == '\r')) // al apachurrar enter, aca se puede hacer que el juego compare la respuesta con enter y no automaticamente, por si se llega a necesitar
            {           
            }*/
            else
            {
                if (t.text.Length < imageName.Length) {
                    t.text += c; //le añade la letra apachurrada al texto
                    }
                }
            }
        }
        if (t.text.Length == imageName.Length && checkText) { //cuando la cantidad de letras tecleadas es igual a la cantidad de letras del nombre de la imagen que es la respuesta como tal
            if (t.text == imageName)  //si el texto es igual a la respuesta correcta pasa a la siguiente
            {
                di.AllowRotation();
                mistakes = 0;
                managerText.ProgressShip();
                HelpEnabled = false;
                checkText = false;
                acertSound.Play();
                diSource.Play();
                //score++;
                Invoke("NextAnswer", 2f);
                //di.displayImage();
                //imageName = di.CurrentImage();
                //t.text = "";
                if (score == 1)
                {
                    managerText.correctAnswers.Answer_1 = true;
                }
                else if (score == 2)
                {
                    managerText.correctAnswers.Answer_2 = true;
                }
                else if (score == 3)
                {
                    managerText.correctAnswers.Answer_3 = true;
                }
                else if (score == 4)
                {
                    managerText.correctAnswers.Answer_4 = true;
                }
                else if (score == 5)
                {
                    managerText.correctAnswers.Answer_5 = true;
                }
                else if (score == 6)
                {
                    managerText.correctAnswers.Answer_6 = true;
                }
                else if (score == 7)
                {
                    managerText.correctAnswers.Answer_7 = true;
                }
                else if (score == 8)
                {
                    managerText.correctAnswers.Answer_8 = true;
                }
                //Invoke("NextAnswer", 1);
            }
            else
            {
                t.color = Color.red;
                checkText = false;
                canWrite = false;
                Invoke("WrongAnswer", 0.5f);
                /*t.text = "";
                mistakes++;
                Debug.Log(mistakes);
                if (mistakes == 3) {
                    HelpEnabled = true;
                }*/
                //aca es donde toca poner el vuelve a intentarlo y sumar un error si la respuesta estaba mal
            }
        }
    }

    void NextAnswer()
    {
        di.displayImage();
        imageName = di.CurrentImage();
        t.text = "";
        score++;
        checkText = true;
    }

    void WrongAnswer() {
        if (!HelpEnabled)
        {
            t.text = "";
        }
        else {
            char c = imageName[0];
            t.text = "" + c;
        }
        
        mistakes++;
        Debug.Log(mistakes);
        canWrite = true;
        checkText = true;
        t.color = Color.white;
        if (mistakes == 3)
        {
            char c = imageName[0];
            t.text = "" + c;
            HelpEnabled = true;
        }
    }

    public void ResetImageName() {
        t.text = "";
        imageName = di.CurrentImage();
        mistakes = 0;
        score = 1;
        HelpEnabled = false;
    }
}
