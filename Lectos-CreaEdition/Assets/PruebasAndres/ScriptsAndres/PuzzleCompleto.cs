﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleto : MonoBehaviour
{
    int aciertos = 0;
    [SerializeField]
    SpriteRenderer completo;

    public AudioClip sonido;
    public AudioClip palabra;

    AudioSource As;
    
    public void Iniciar ()
    {
        As = GetComponent<AudioSource>();
        As.clip = palabra;
        As.Play();
    }

    public void SumarRespuesta ()
    {
        aciertos++;
        if (aciertos == 6)
        {
            As.clip = sonido;
            completo.color = Color.white;
            completo.sortingOrder = 11;
            As.Play();
        }
    }
}
