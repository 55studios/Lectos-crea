using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Dictado", menuName = "Minigames/Dictado")]
public class Dictado : MinigameData
{
    private void OnEnable()
    {
        Tipo = 9;
        Template = "TemplateDictado";
    }

    public SpriteAsset[] imagenes;
    public AudioClip[] sonidoRespuestas;
    public GameObject[] prefabPalabras;
}
