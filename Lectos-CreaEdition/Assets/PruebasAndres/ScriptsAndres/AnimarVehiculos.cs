using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarVehiculos : MonoBehaviour
{
    public GameObject[] vehiculos;

    int index = 0;

    public void Iniciar()
    {
        //print("iniciado");
        if (vehiculos[0].activeSelf == false)
        {
            vehiculos[0].SetActive(true);
            MoverPrimero();
        }
    }

    public void Mover()
    {
        if (vehiculos.Length == 1)
        {
            vehiculos[0].SendMessage("Mover");
        } else
        {
            vehiculos[index].SendMessage("Mover");
            index++;
            if (index != vehiculos.Length)
            {
                vehiculos[index].SetActive(true);
                vehiculos[index].SendMessage("Mover");
            }
        }
    }

    public void AsteroideVacio ()
    {
        index++;
        if (index != vehiculos.Length)
        {
            vehiculos[index].SetActive(true);
            vehiculos[index].SendMessage("Mover");
        }

    }

    void MoverPrimero ()
    {
        vehiculos[index].SendMessage("Mover");
    }
}