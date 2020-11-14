using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Memoria", menuName = "Minigames/Memoria")]
public class Memoria : MinigameData
{
    public void OnEnable()
    {
        Tipo = 2;
        Template = "TemplateMemoria";
    }

    public AudioClip flip;

    public SpriteAsset[] parejasElemento1;
    public SpriteAsset[] parejasElemento2;
}
