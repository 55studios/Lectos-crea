using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo minijuego", menuName = "Minijuego")]
public class ScriptableScene : ScriptableObject
{
    public int puntosLogrables;
    public string reward;
    public int tipoMinijuego;
    public Sprite[] activadores;
    public Sprite[] receptores;
    public string[] respuestasTexto;
}