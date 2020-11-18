using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Habitaciones", menuName = "Minigames/Habitaciones")]
public class Habitaciones : MinigameData
{
    private void OnEnable()
    {
        Tipo = 7;
        Template = "TemplateHabitaciones";
    }
}
