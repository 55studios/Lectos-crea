using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CorrectAnswersCasa
{
    public bool GameInit;
    public bool Answer_1;
    public bool Answer_2;
    public bool Answer_3;
    public bool Answer_4;
    public bool GameWin;
}
public class ConectorManagerCN : MonoBehaviour {

    [Header("Tren")]
    public Animator train;

    [Header("Pocisiones Finales por ronda")]
    public GameObject[] objectsActivators;
    public GameObject[] objectsReceptors;
    public Transform[] SpwanActivators;
    public Transform[] SpawnReceptors;

    public CorrectAnswersCasa correctAnswers;

    [Space(5)]
    [Header("Timer")]
    public float CountDown = 50;
    public Slider slider;
    public Text text;

    [Space(5)]
    [Header("Buttons")]
    public GameObject InitShuffle;
    public ParticleSystem Explotion;

    [Space(5)]
    [Header("Panels")]
    public GameObject PanelWin;
    public GameObject PanelLose;
    public Text recordTime;
    public Slider progressLvl;

    private int countPoints;
    private int count = 0;
    private bool startTime = false;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitShuffle.SetActive(true);
        PanelLose.SetActive(false);
        PanelWin.SetActive(false);
    }
    public void Shuffle()
    {
        countPoints = 0;
        progressLvl.value = 0;

        train.SetTrigger("Start");
        correctAnswers.GameWin = false;
        correctAnswers.GameInit = true;
        correctAnswers.Answer_1 = false;
        correctAnswers.Answer_2 = false;
        correctAnswers.Answer_3 = false;
        correctAnswers.Answer_4 = false;


        foreach (Transform item in SpwanActivators)
        {
            int selectionRandom = 0;
            //int selectionRandom = Random.Range(0, objectsActivators.Length);

            var objectActivator = Instantiate(objectsActivators[count],
                SpwanActivators[count].position, Quaternion.identity) as GameObject;
            var objectReceptor = Instantiate(objectsReceptors[count],
                SpawnReceptors[count].position, Quaternion.identity) as GameObject;


            objectActivator.name = "Activators " + count.ToString();
            objectActivator.GetComponent<ActivatorsCN>().id = count;

            objectReceptor.name = "Receptor " + count.ToString();
            objectReceptor.GetComponentInChildren<ReceptorCN>().id = count;
            objectReceptor.transform.parent = SpawnReceptors[count].transform;

            count += 1;
            selectionRandom += 1;
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
        Explotion.Play();

    }
    public void CheckLvl()
    {
        gameManager.MiniGamesSubLevel_1[1] = true;
    }

    void Update()
    {

        if (startTime)
        {
            CountDown -= Time.deltaTime;
            slider.value = CountDown;
            text.text = CountDown.ToString("F0") + " Segundos";

            if (CountDown <= 0 || correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4)
            {
                if (correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4)
                {
                    startTime = false;
                    correctAnswers.GameWin = true;
                    train.SetTrigger("Next");
                    recordTime.text = (50 - CountDown).ToString("F2");
                    correctAnswers.GameInit = false;
                    CountDown = 0;
                    gameManager.MiniGamesSubLevel_1[0] = true;
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
                    train.SetTrigger("Again");
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