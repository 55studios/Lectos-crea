using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Rompecabezas", menuName = "Minigames/Rompecabezas")]
public class Puzzle : MinigameData
{
    private void OnEnable()
    {
        Tipo = 8;
        Template = "TemplateRompecabezas";
    }
}
