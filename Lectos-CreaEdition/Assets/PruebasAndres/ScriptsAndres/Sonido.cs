using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{

    PlaySonidos playS;
    public Sprite[] frames;
    int frame = 0;
    public bool clickeable;

    // Start is called before the first frame update
    void Start()
    {
        playS = GameObject.FindGameObjectWithTag("Reproductor").GetComponent<PlaySonidos>();
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && clickeable)
        {
            if (playS.audioActual == GetComponent<Respuesta>().respuesta)
            {
                clickeable = false;
                playS.CambiarAudio();
                GameObject controlador = GameObject.FindWithTag("GameController");
                controlador.GetComponent<CreateLevel>().RespuestaCorrecta();
                InvokeRepeating("animar", 0, 0.1f);
                Destroy(gameObject, 1f);
            }
        }
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
