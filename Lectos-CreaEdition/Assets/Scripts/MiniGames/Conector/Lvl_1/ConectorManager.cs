using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

public class ConectorManager : MonoBehaviour {
    
    #region positions
    [Header("Pocisiones Finales por ronda")]
    public GameObject[] objectsActivators;
    public GameObject[] objectsReceptors;
    public Transform[] SpwanActivators;
    public Transform[] SpawnReceptors;
    public GameObject separator;
    #endregion

    public CorrectAnswers correctAnswers;
   
    #region Time
    [Space(5)]
    [Header("Timer")]
    public float CountDown = 60;
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

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitShuffle.SetActive(true);
        PanelLose.SetActive(false);
        PanelWin.SetActive(false);
        separator.SetActive(false);
    }
    public void Shuffle()
    {
        countPoints = 0;
        progressLvl.value = 0;

        correctAnswers.GameWin = false;
        correctAnswers.GameInit = true;
        correctAnswers.Answer_1 = false;
        correctAnswers.Answer_2 = false;
        correctAnswers.Answer_3 = false;
        correctAnswers.Answer_4 = false;
        correctAnswers.Answer_5 = false;

        foreach (Transform item in SpwanActivators)
        {
            int selectionRandom = 0;
            //int selectionRandom = Random.Range(0, objectsActivators.Length);

            var objectActivator = Instantiate(objectsActivators[count],
                SpwanActivators[count].position, Quaternion.identity) as GameObject;
            var objectReceptor = Instantiate(objectsReceptors[count],
                SpawnReceptors[count].position, Quaternion.identity) as GameObject;


            objectActivator.name = "Activators " + count.ToString();
            objectActivator.GetComponent<Activators>().id = count;

            objectReceptor.name = "Receptor " + count.ToString();
            objectReceptor.GetComponentInChildren<Receptors>().id = count;
            count += 1;
            selectionRandom += 1;
        }
        separator.SetActive(true);
        PanelWin.SetActive(false);
        PanelLose.SetActive(false);
        InitShuffle.SetActive(false);
        startTime = true;
        count = 0;
        CountDown = 60;

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
                    recordTime.text = (60 - CountDown).ToString("F2");
                    startTime = false;
                    correctAnswers.GameWin = true;
                    correctAnswers.GameInit = false;
                    CountDown = 0;
                    gameManager.MiniGamesSubLevel_1[0] = true;
                    separator.SetActive(false);
                    StartCoroutine(TimeToactive());
                }
                else
                {
                    CountDown = 0;
                    PanelLose.SetActive(true);
                    startTime = false;
                    correctAnswers.GameInit = false;
                    correctAnswers.Answer_1 = false;
                    correctAnswers.Answer_2 = false;
                    correctAnswers.Answer_3 = false;
                    correctAnswers.Answer_4 = false;
                    correctAnswers.Answer_5 = false;
                    separator.SetActive(false);

                }   
            }
        }
    }
    IEnumerator TimeToactive()
    {
        yield return new WaitForSeconds(2);
       
        PanelWin.SetActive(true);
    }
}