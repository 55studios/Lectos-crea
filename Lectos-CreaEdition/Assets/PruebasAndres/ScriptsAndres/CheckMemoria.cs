using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMemoria : MonoBehaviour
{

    GameObject[] objetos;
    GameObject controlador;

    int activados;

    void Start()
    {
        objetos = new GameObject[2];
        controlador = GameObject.FindWithTag("GameController");
    }

    public void Activar(GameObject Go)
    {
        if (activados != 2)
        {
            Go.GetComponent<SpriteRenderer>().color = Color.white;
            Go.GetComponent<Memoria>().activado = true;
            activados++;
            objetos[activados - 1] = Go;
            if (activados == 2)
            {
                if (objetos[0].GetComponent<Respuesta>().respuesta == objetos[1].GetComponent<Respuesta>().respuesta)
                {                   
                    controlador.GetComponent<CreateLevel>().RespuestaCorrecta();
                    Destroy(objetos[0], 1f);
                    Destroy(objetos[1], 1f);
                    Invoke("NoActivados", 1f);
                }
                else
                {                    
                    Invoke("Desactivar", 1f);
                }
            }
        }    
    }

    void NoActivados ()
    {
        activados = 0;
    }

    void Desactivar ()
    {
        objetos[0].GetComponent<SpriteRenderer>().color = Color.black;
        objetos[1].GetComponent<SpriteRenderer>().color = Color.black;
        objetos[0].GetComponent<Memoria>().activado = false;
        objetos[1].GetComponent<Memoria>().activado = false;
        activados = 0;
    }
}
