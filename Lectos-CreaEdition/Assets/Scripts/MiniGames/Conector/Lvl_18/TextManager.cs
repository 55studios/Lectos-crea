using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class CorrectAnswersTextInput
{
    public bool GameInit = true;
    public bool Answer_1;
    public bool Answer_2;
    public bool Answer_3;
    public bool Answer_4;
    public bool Answer_5;
    public bool Answer_6;
    public bool Answer_7;
    public bool Answer_8;
    public bool GameWin;
}
public class TextManager : MonoBehaviour
{

        public CorrectAnswersTextInput correctAnswers;

        #region Time
        [Space(5)]
        [Header("Timer")]
        public float CountDown = 25;
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
        public GameObject Input;
        public TextInput textManager;
        public GameObject PanelWin;
        public GameObject PanelLose;
        public Text recordTime;
        public Slider progressLvl;
    public DisplayImages Di;
        #endregion
        #region Privates
    private int count = 0;
    private int countPoints = 0;
    private bool startTime = false;
    private GameManager gameManager;
    private DisplayImages displayImages;
        #endregion

        private void Awake()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        displayImages = GameObject.Find("ImageDisplay").GetComponent<DisplayImages>();
        InitShuffle.SetActive(true);
            PanelLose.SetActive(false);
            PanelWin.SetActive(false);
            Input.SetActive(false);
            textManager.enabled = false;
        }

        public void Shuffle()
        {
            if (correctAnswers.GameWin == false)
            {
                countPoints = 0;
                progressLvl.value = 0;
                #region answers
                correctAnswers.GameWin = false;
                correctAnswers.GameInit = true;
                correctAnswers.Answer_1 = false;
                correctAnswers.Answer_2 = false;
                correctAnswers.Answer_3 = false;
                correctAnswers.Answer_4 = false;
                correctAnswers.Answer_5 = false;
                correctAnswers.Answer_6 = false;
                correctAnswers.Answer_7 = false;
                correctAnswers.Answer_8 = false;
                #endregion
                Input.SetActive(true);
                textManager.enabled = true;
                Di.index = 0;
                Di.HideAllImages();
                textManager.ResetImageName();
                PanelWin.SetActive(false);
                PanelLose.SetActive(false);
                InitShuffle.SetActive(false);
                startTime = true;
                count = 0;
                CountDown = 120;
            }
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

            if (startTime){

            CountDown -= Time.deltaTime;
            slider.value = CountDown;
            text.text = CountDown.ToString("F0") + " Segundos";

                if (CountDown <= 0 || correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4 && correctAnswers.Answer_5
                    && correctAnswers.Answer_6 && correctAnswers.Answer_7 && correctAnswers.Answer_8){
                    if (correctAnswers.Answer_1 && correctAnswers.Answer_2 && correctAnswers.Answer_3 && correctAnswers.Answer_4 && correctAnswers.Answer_5
                        && correctAnswers.Answer_6 && correctAnswers.Answer_7 && correctAnswers.Answer_8){
                    //displayImages.index = 0;
                    recordTime.text = (120 - CountDown).ToString("F2");
                        //Input.SetActive(false);
                        //textManager.enabled = false;
                        StartCoroutine(TimeToactive());
                    
                    }
                    else
                    {
                        //CountDown = 0;
                        PanelLose.SetActive(true);
                        startTime = false;
                    #region answers
                    correctAnswers.GameInit = false;
                        correctAnswers.Answer_1 = false;
                        correctAnswers.Answer_2 = false;
                        correctAnswers.Answer_3 = false;
                        correctAnswers.Answer_4 = false;
                        correctAnswers.Answer_5 = false;
                        correctAnswers.Answer_6 = false;
                        correctAnswers.Answer_7 = false;
                        correctAnswers.Answer_8 = false;
                    #endregion
                    Input.SetActive(false);
                    textManager.enabled = false;
                    }
                }
            }
        }

        IEnumerator TimeToactive()
        {
            yield return new WaitForSeconds(2);
        displayImages.index = 0;
        textManager.enabled = false;
        Input.SetActive(false);
        startTime = false;
            correctAnswers.GameWin = true;
            correctAnswers.GameInit = false;
            CountDown = 0;
            gameManager.MiniGamesSubLevel_1[0] = true;

            PanelWin.SetActive(true);
        yield return new WaitForSeconds(3);
        correctAnswers.GameWin = false;
    }
}

