using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Canchas", menuName = "Minigames/Canchas")]
public class Canchas : MinigameData
{
    private void OnEnable()
    {
        Tipo = 6;
        Template = "Template5-5";
        Ind = 0;
    }
    public SpriteAsset[] arrastrables;
    public SpriteAsset[] receptores;
    public SpriteAsset[] animacionFinal;

    public AudioClip[] sonidosArrastrar;
    public AudioClip[] sonidosCorrecto;
}
