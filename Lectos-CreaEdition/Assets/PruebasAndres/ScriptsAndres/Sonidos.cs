using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Sonidos", menuName = "Minigames/Sonidos")]
public class Sonidos : MinigameData
{
    private void OnEnable()
    {
        Tipo = 3;
        Template = "TemplateSonido";
        Ind = 1;
    }

    public SpriteAsset[] clickeables;
    public SpriteAsset[] animacionCorrecto;

    public AudioClip[] sonidosParlante;
    public AudioClip[] sonidosCorrecto;
}
