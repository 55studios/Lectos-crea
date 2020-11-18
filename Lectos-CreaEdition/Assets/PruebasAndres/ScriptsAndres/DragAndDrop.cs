using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Drag&Drop", menuName = "Minigames/Drag&Drop")]
public class DragAndDrop : MinigameData
{
    private void OnEnable()
    {
        Tipo = 0;
        Template = "Template5-1";
    }
    [HideInInspector]
    public int variante = 0;
    public SpriteAsset[] arrastrables;
    public SpriteAsset[] receptores;

    public AudioClip[] sonidosArrastrar;
    public AudioClip[] sonidosCorrecto;
}
