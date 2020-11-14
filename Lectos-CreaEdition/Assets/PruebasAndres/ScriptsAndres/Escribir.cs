using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Escribir", menuName = "Minigames/Escribir")]
public class Escribir : MinigameData
{
    public void OnEnable()
    {
        Tipo = 1;
        Template = "TemplateEscribir";
    }

    public SpriteAsset[] respuestas;
    public AudioClip[] sonidosRespuestas;
}
