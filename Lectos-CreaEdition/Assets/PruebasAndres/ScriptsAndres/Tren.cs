using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Tren", menuName = "Minigames/Tren")]
public class Tren : MinigameData
{
    private void OnEnable()
    {
        Tipo = 5;
        Template = "TemplateTren";
    }

    public SpriteAsset[] arrastrables;
    public SpriteAsset[] receptores;

    public AudioClip[] sonidosArrastrar;
    public AudioClip[] sonidosCorrecto;
}
