using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventoToClick : MonoBehaviour {

    public UnityEvent Click;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        Click.Invoke();
        gameManager.trofeo = true;
    }
}
