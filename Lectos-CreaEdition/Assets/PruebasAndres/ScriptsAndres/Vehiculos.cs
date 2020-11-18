using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Vehiculos", menuName = "Minigames/Vehiculos")]
public class Vehiculos : MinigameData
{
    private void Awake()
    {
        Tipo = 5;
        switch ((int)variacion)
        {
            case 0:
                Template = "TemplateTren";
                break;
            case 1:
                Template = "TemplateNaves";
                break;
            case 2:
                Template = "TemplateAsteroides";
                break;
            case 3:
                Template = "TemplateEstrellas";
                break;
            default:                
                break;
        }
    }

    [HideInInspector]
    public int variante = 2;
    public enum Variacion {Tren, naves, asteroides, estrellas};
    public Variacion variacion;

    public SpriteAsset[] arrastrables;
    public SpriteAsset[] receptores;

    public AudioClip[] sonidosArrastrar;
    public AudioClip[] sonidosCorrecto;
}
