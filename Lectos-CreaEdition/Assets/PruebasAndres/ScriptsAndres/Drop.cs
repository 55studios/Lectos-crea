using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    bool correcta;
    GameObject activadorCorrecto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && correcta)
        {
            Destroy(gameObject);
            Destroy(activadorCorrecto);
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().RespuestaCorrecta();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Respuesta>().respuesta == collision.GetComponent<Respuesta>().respuesta)
        {
            correcta = true;
            activadorCorrecto = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        correcta = false;
    }
}
