using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Events : MonoBehaviour {

    public UnityEvent ActivateToTouchMe;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        ActivateToTouchMe.Invoke();
    }
}
