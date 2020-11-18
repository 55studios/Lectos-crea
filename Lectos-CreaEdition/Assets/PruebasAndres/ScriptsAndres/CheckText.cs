using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckText : MonoBehaviour
{
    Text t;
    string respuesta;
    bool completo;
    int indexsonido;
    public AudioSource audioS;
    public AudioClip[] misSonidos;

    // Start is called before the first frame update
    void Start()
    {
        indexsonido = 0;
        t = GameObject.FindWithTag("Texto").GetComponent<Text>();
        respuesta = GetComponent<RespuestaTexto>().respuesta;       
    }


    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // al apachurrar delete borra 
            {
                if (t.text.Length != 0)
                {
                    t.text = t.text.Substring(0, t.text.Length - 1);
                }
            }
            /*else if ((c == '\n') || (c == '\r')) // al apachurrar enter, aca se puede hacer que el juego compare la respuesta con enter y no automaticamente, por si se llega a necesitar
            {           
            }*/
            else
            {
                if (t.text.Length < respuesta.Length)
                {
                    t.text += c; //le añade la letra apachurrada al texto
                    completo = false;
                }
            }
        }

        if (t.text.Length == respuesta.Length)
        { //cuando la cantidad de letras tecleadas es igual a la cantidad de letras del nombre de la imagen que es la respuesta como tal
            completo = true;
            if (t.text == respuesta)  //si el texto es igual a la respuesta correcta pasa a la siguiente
            {
                print("Correctin");
                Destroy(gameObject);
                GameObject controlador = GameObject.FindWithTag("GameController");
                controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
                t.text = "";
            }
            else
            {
                //aca es donde toca poner el vuelve a intentarlo y sumar un error si la respuesta estaba mal
            }
        }
    }

    public void AgregarChar (string c)
    {
        if (!completo && c.Length == 1)
        {
            t.text += c;
        }
        else if (t.text.Length > 0 && c == "Borrar")
        {
            completo = false;
            t.text = t.text.Substring(0, t.text.Length - 1);
        }
    }

    void IniciarSonidoRespuesta ()
    {
        if (audioS != null && misSonidos != null)
        {
            audioS.Stop();
            audioS.clip = misSonidos[indexsonido];
            audioS.Play();
        }
    }
}
