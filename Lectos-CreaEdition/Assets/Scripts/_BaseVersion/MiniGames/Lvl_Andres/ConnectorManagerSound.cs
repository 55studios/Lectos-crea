using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
[System.Serializable]
public class CorrectAnswers
{
    public bool GameInit = true;
    public bool Answer_1;
    public bool Answer_2;
    public bool Answer_3;
    public bool Answer_4;
    public bool Answer_5;
    public bool GameWin;
}
*/
public class ConnectorManagerSound : MonoBehaviour {

    #region positions
    [Header("Pocisiones Finales por ronda")]
    public GameObject[] objectsActivators;
    public GameObject soundTextManager;
    public GameObject reproducir;
    //public GameObject[] objectsReceptors;
    //public Transform[] SpwanActivators;
    //public Transform[] SpawnReceptors;
    #endregion

    public CorrectAnswers correctAnswers;

    #region Time
    [Space(5)]
    [Header("Timer")]
    public float CountDown = 50;
    public Slider slider;
    public Text text;
    #endregion
    #region Buttons
    [Space(5)]
    [Header("Buttons")]
    public GameObject InitShuffle;
    public ParticleSystem explotion;
    #endregion
    #region Panel
    [Space(5)]
    [Header("Panels")]
    public GameObject PanelWin;
    public GameObject PanelLose;
    public Text recordTime;
    public Slider progressLvl;
    #endregion
    #region Privates
    private int count = 0;
    private int countPoints = 0;
    private bool startTime = false;
    private GameManager gameManager;
    #endregion

    public GameObject leckticia;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitShuffle.SetActive(true);
        PanelLose.SetActive(false);
        PanelWin.SetActive(false);
    }
    public void Shuffle()
    {
        if (leckticia != null) {
            leckticia.SetActive(true);
        }
        countPoints = 0;
        progressLvl.value = 0;

        correctAnswers.GameWin = false;
        correctAnswers.GameInit = true;
        correctAnswers.Answer_1 = false;
        correctAnswers.Answer_2 = false;
        correctAnswers.Answer_3 = false;
        correctAnswers.Answer_4 = false;
        correctAnswers.Answer_5 = false;

        soundTextManager.GetComponent<STmanager>().index = 0;
        soundTextManager.GetComponent<STmanager>().ResetAnswers();
        reproducir.SetActive(true);

        foreach (GameObject item in objectsActivators)
        {
            item.SetActive(true);
            item.GetComponent<STpoint>().word.gameObject.SetActive(true);
            item.GetComponent<STpoint>().picture.transform.GetComponent<Image>().enabled = false;
            item.GetComponent<Button>().interactable = true;
            //int selectionRandom = 0;
            //int selectionRandom = Random.Range(0, objectsActivators.Length);

            //var objectActivator = Instantiate(objectsActivators[count],
            //SpwanActivators[count].position, Quaternion.identity) as GameObject;
            /* var objectReceptor = Instantiate(objectsReceptors[count],
                 SpawnReceptors[count].position, Quaternion.identity) as GameObject;*/


            //objectActivator.name = "Activators " + count.ToString();
            //objectActivator.GetComponent<STpoint>().id = count;

            /*objectReceptor.name = "Receptor " + count.ToString();
            objectReceptor.GetComponentInChildren<Receptors>().id = count;*/
            //count += 1;
            //selectionRandom += 1;
        }

        PanelWin.SetActive(false);
        PanelLose.SetActive(false);
        InitShuffle.SetActive(false);
        startTime = true;
        count = 0;
        CountDown = 50;

    }

    public void ProgressShip()
    {
        countPoints += 1;
        progressLvl.value = countPoints;
        explotion.Play();

    }

    public void CheckLvl()
    {
        gameManager.MiniGamesSubLevel_1[0] = true;
    }

    void Update()
    {

        if (startTime)
        {
            CountDown -= Time.deltaTime;
            slider.value = CountDown;
            text.text = CountDown.ToString("F0") + " Segundos";

            if (CountDown <= 0 || correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4 && correctAnswers.Answer_5)
            {
                if (correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4 && correctAnswers.Answer_5)
                {
                    foreach (GameObject item in objectsActivators)
                    {
                        //item.GetComponent<STpoint>().picture.transform.GetComponent<Image>().enabled = false;
                        item.GetComponent<Button>().interactable = false;
                    }
                    if (leckticia != null) {
                        leckticia.SetActive(false);
                    }
                    recordTime.text = (50 - CountDown).ToString("F2");
                    reproducir.SetActive(false);
                    startTime = false;
                    correctAnswers.GameWin = true;
                    correctAnswers.GameInit = false;
                    CountDown = 0;
                    gameManager.MiniGamesSubLevel_1[0] = true;
                    StartCoroutine(TimeToactive());

                }
                else
                {
                    foreach (GameObject item in objectsActivators)
                    {
                        item.GetComponent<STpoint>().word.gameObject.SetActive(false);
                        item.GetComponent<STpoint>().picture.transform.GetComponent<Image>().enabled = false;
                        item.GetComponent<Button>().interactable = false;
                    }
                    if (leckticia != null)
                    {
                        leckticia.SetActive(false);
                    }
                    reproducir.SetActive(false);
                    CountDown = 0;
                    PanelLose.SetActive(true);
                    startTime = false;
                    correctAnswers.GameInit = false;
                    correctAnswers.Answer_1 = false;
                    correctAnswers.Answer_2 = false;
                    correctAnswers.Answer_3 = false;
                    correctAnswers.Answer_4 = false;
                    correctAnswers.Answer_5 = false;

                }
            }
        }
    }

    IEnumerator TimeToactive()
    {
        yield return new WaitForSeconds(2);
        foreach (GameObject item in objectsActivators)
        {
            item.GetComponent<STpoint>().picture.transform.GetComponent<Image>().enabled = false;
            //item.GetComponent<Button>().interactable = false;
        }
        PanelWin.SetActive(true);
    }
}
