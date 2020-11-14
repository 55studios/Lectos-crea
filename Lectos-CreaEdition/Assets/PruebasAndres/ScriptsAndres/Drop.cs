using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    bool correcta;
    GameObject activadorCorrecto;
    public Sprite[] frames;
    int frame = 0;
    public bool hielo;
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && correcta)
        {
            
            Destroy(activadorCorrecto);
            if (frames.Length > 1)
            {
                cambiarImagen();
                InvokeRepeating("animar", 0, 0.1f);
            } else
            {
                cambiarImagen();
            }
            if (hielo)
            {
                transform.Find("Hielo").gameObject.SetActive(false);
            }            
            Destroy(gameObject, 1f);
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

    void animar()
    {
        GetComponent<SpriteRenderer>().sprite = frames[frame];
        frame++;
        if (frame == frames.Length - 1)
        {
            frame = 0;
        }
    }

    void cambiarImagen ()
    {
        print("se llamo");
        GameObject controlador = GameObject.FindWithTag("GameController");
        controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
    }
}
