﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo minijuego", menuName = "Minijuego")]
public class ScriptableScene : ScriptableObject
{
    public int puntosLogrables;
    public string reward;
    public AudioClip acierto;
    public enum Tipo {draganddrop, escribir, memoria, sonidos};
    public Tipo tipoDeMinijuego;
    public string[] activadores;
    public string[] receptores;
    public enum Locacion {Ama1, Ama2, Ama3, prueba = 100 };
    public Locacion locacion;
    [HideInInspector]
    public string path;

    private void Awake()
    {
        switch ((int)locacion)
        {
            case 0:
                path = "Ama1/";
                break;
            case 1:
                path = "Ama2/";
                break;
            case 2:
                path = "Ama3/";
                break;
            case 100:
                path = "Imagenes/";
                break;
            default:
                break;
        }
    }
}