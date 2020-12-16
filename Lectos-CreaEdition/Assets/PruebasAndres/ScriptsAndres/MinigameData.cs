﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameData : ScriptableObject
{
    int t = 0;
    public int Tipo
    {
        get { return t; }
        set { t = value; }
    }

    string tem;
    public string Template
    {
        get { return tem; }
        set { tem = value; }
    }
    int ind = 0;
    public int Ind
    {
        get { return ind; }
        set { ind = value; }
    }
    public int puntosLogrables;
    public float[] tiemposAVencer = new float[3];
    public string reward;

    public AudioClip sonidoAcierto;
    public GameObject particulasAcierto;
}
