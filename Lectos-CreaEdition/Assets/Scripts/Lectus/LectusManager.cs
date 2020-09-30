using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
public class LectusManager : MonoBehaviour {

    public GameObject lectusRobot;
    public float timeOfActivation;
    private ProCamera2DTransitionsFX _transition;

    void Start()
    {
        _transition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ProCamera2DTransitionsFX>();
        _transition.TransitionEnter();
        lectusRobot.SetActive(false);
        Invoke("ActivateToLectus", timeOfActivation);
    }

    // Update is called once per frame
    void ActivateToLectus()
    {
        lectusRobot.SetActive(true);
    }
}
