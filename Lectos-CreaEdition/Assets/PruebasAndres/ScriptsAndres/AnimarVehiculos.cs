using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarVehiculos : MonoBehaviour
{
    public GameObject[] vehiculos;

    int index = 0;

    private void Start()
    {
        if (vehiculos[0].activeSelf == false)
        {
            vehiculos[0].SetActive(true);
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
            }
        }
    }
}