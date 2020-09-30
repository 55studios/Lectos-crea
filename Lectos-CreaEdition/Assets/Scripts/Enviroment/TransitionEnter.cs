using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
public class TransitionEnter : MonoBehaviour {

    private ProCamera2DTransitionsFX _transition;

    void Start()
    {
        _transition = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ProCamera2DTransitionsFX>();
        _transition.TransitionEnter();
  
    }

    
}
