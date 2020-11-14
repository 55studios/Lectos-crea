using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lista minigames", menuName = "ListaMinigames")]
public class ListaMinigames : ScriptableObject
{
    public MinigameData[] lista;
}
