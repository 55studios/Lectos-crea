using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    bool correcta;
    bool incorrecta;
    GameObject activadorCorrecto;
    AudioSource errorAS;
    public Sprite[] frames;
    int frame = 0;
    public bool hielo;
    public bool vehiculos;
    public bool temporal;
    public Transform posActivador;
    public AudioSource audioS;
    public AudioClip miSonido;

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && correcta)
        {
            if (audioS != null && miSonido != null)
            {
                audioS.Stop();
                audioS.clip = miSonido;
                audioS.Play();
            }
            if (frames.Length > 1)
            {
                CambiarImagen();
                InvokeRepeating("Animar", 0, 0.1f);
            } else
            {
                CambiarImagen();
            }
            if (hielo)
            {
                transform.Find("Hielo").gameObject.SetActive(false);
            }
            if (vehiculos)
            {
                activadorCorrecto.transform.SetParent(gameObject.transform);
                activadorCorrecto.GetComponent<Drag>().enabled = false;
                activadorCorrecto.transform.position = posActivador.position;
                GameObject.FindWithTag("AnimadorVehiculos").GetComponent<AnimarVehiculos>().Mover();
            } else
            {
                if (!temporal)
                {
                    Destroy(activadorCorrecto);
                    Destroy(gameObject, 1f);
                }               
            }
             if (temporal)
            {
                activadorCorrecto.GetComponent<Drag>().enabled = false;
                activadorCorrecto.transform.position = transform.position;
                Destroy(gameObject);
            }
        } else if (Input.GetMouseButtonUp(0) && incorrecta)
        {
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().Error();
            print("llamando error");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Respuesta>().respuesta == collision.GetComponent<Respuesta>().respuesta)
        {
            correcta = true;
            activadorCorrecto = collision.gameObject;
        } else
        {
            incorrecta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        correcta = false;
        incorrecta = false;
    }

    void Animar()
    {
        GetComponent<SpriteRenderer>().sprite = frames[frame];
        frame++;
        if (frame == frames.Length - 1)
        {
            frame = 0;
        }
    }

    void CambiarImagen ()
    {
        print("se llamo");
        GameObject controlador = GameObject.FindWithTag("GameController");
        controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
    }

    private void OnMouseUp()
    {
        //if (!correcta)
        //{
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().Error();
            print("llamando error");
        //}
    }
}
