using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    bool correcta;
    GameObject activadorCorrecto;
    public Sprite[] frames;
    int frame = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && correcta)
        {
            Destroy(gameObject, 1f);
            Destroy(activadorCorrecto);
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().RespuestaCorrecta();
            InvokeRepeating("animar", 0, 0.1f);
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
}
