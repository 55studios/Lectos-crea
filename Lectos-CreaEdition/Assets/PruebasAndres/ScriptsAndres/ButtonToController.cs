using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToController : MonoBehaviour
{

    public CreateLevel controlador;
    public ListaMinigames Lista;
    public int index;

    public void CrearMinijuego ()
    {
        MinigameData Md = Lista.lista[index];
        controlador.MGD = Md;
        controlador.Cargar(Md.Template);
        controlador.SetNextLevelButton(Lista, index);
    }
}
