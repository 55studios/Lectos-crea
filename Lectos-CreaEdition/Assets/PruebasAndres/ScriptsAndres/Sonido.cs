using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{

    PlaySonidos playS;
    public Sprite[] frames;
    int frame = 0;
    public bool clickeable;
    public AudioSource audioS;
    public AudioClip miSonido;

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
                if (audioS != null && miSonido != null)
                {
                    audioS.Stop();
                    audioS.clip = miSonido;
                    audioS.Play();
                }
                clickeable = false;
                playS.CambiarAudio();
                GameObject controlador = GameObject.FindWithTag("GameController");
                controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
                if (frames.Length > 1 && frames != null)
                {
                    InvokeRepeating("animar", 0, 0.2f);
                    transform.localScale = new Vector3(0.3f, 0.3f, 1);
                }                
                Destroy(gameObject, 1f);
            } else
            {
                GameObject controlador = GameObject.FindWithTag("GameController");
                controlador.GetComponent<CreateLevel>().Error();
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
