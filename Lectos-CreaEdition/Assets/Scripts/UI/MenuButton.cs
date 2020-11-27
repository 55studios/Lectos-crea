using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuButton : MonoBehaviour
{
    public CreateLevel controllerGameState;
    public bool StateGame;
    public GameObject ButtonsPlanet;
    public GameObject ButtonsGame;

    public bool ButtonState = false;

    void Start()
    {
        ButtonsPlanet.SetActive(true);
        ButtonsGame.SetActive(false);
    }

    public void DetectChanges(bool ActualState) {
        StateGame = ActualState;
        if (!StateGame) {
            ButtonsPlanet.SetActive(true);
            ButtonsGame.SetActive(false);
            AnimationsOut();
        }
        else {
            ButtonsPlanet.SetActive(false);
            ButtonsGame.SetActive(true);
            AnimationsOut();
        }
    }

    public void AnimationsIn() {
        if (!StateGame) {
            ButtonsPlanet.transform.GetChild(0).GetComponent<ScaleAnimationInOut>().InAnimation();
            ButtonsPlanet.transform.GetChild(1).GetComponent<ScaleAnimationInOut>().InAnimation();
        }
        else {
            ButtonsGame.transform.GetChild(0).GetComponent<ScaleAnimationInOut>().InAnimation();
            ButtonsGame.transform.GetChild(1).GetComponent<ScaleAnimationInOut>().InAnimation();
        }
    }

    public void AnimationsOut() {
        if (!StateGame) {
            ButtonsPlanet.transform.GetChild(0).GetComponent<ScaleAnimationInOut>().OutAnimation();
            ButtonsPlanet.transform.GetChild(1).GetComponent<ScaleAnimationInOut>().OutAnimation();
        }
        else {
            ButtonsGame.transform.GetChild(0).GetComponent<ScaleAnimationInOut>().OutAnimation();
            ButtonsGame.transform.GetChild(1).GetComponent<ScaleAnimationInOut>().OutAnimation();
        }
    }

    public void ButtonEventTouch() {
        ButtonState = !ButtonState;
        if (ButtonState ) {
            AnimationsIn();
        }
        else{
            AnimationsOut();
        }
    }
}
