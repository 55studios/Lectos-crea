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
            Go.GetComponent<Memo>().activado = true;
            Go.transform.Find("Back").gameObject.SetActive(false);
            activados++;
            objetos[activados - 1] = Go;
            if (activados == 2)
            {
                if (objetos[0].GetComponent<Respuesta>().respuesta == objetos[1].GetComponent<Respuesta>().respuesta)
                {                   
                    controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
                    Destroy(objetos[0], 1f);
                    Destroy(objetos[1], 1f);
                    Invoke("NoActivados", 1f);
                }
                else
                {                    
                    Invoke("Desactivar", 1f);
                    controlador.GetComponent<CreateLevel>().Error();
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
        objetos[0].transform.Find("Back").gameObject.SetActive(true);
        objetos[1].transform.Find("Back").gameObject.SetActive(true);
        objetos[0].GetComponent<Memo>().activado = false;
        objetos[1].GetComponent<Memo>().activado = false;
        activados = 0;
    }
}
