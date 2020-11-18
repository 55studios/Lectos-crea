using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Congelados", menuName = "Minigames/Congelados")]
public class Congelados : MinigameData
{
    private void OnEnable()
    {
        Tipo = 4;
        Template = "TemplateCongelados";
    }

    [HideInInspector]
    public int variante = 1;
    public SpriteAsset[] arrastrables;
    public SpriteAsset[] receptores;

    public AudioClip[] sonidosArrastrar;
    public AudioClip[] sonidosCorrecto;
}
