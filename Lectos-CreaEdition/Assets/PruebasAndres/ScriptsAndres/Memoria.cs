using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memoria : MonoBehaviour
{
    public GameObject checker;
    public bool activado;

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && !activado)
        {
            checker.GetComponent<CheckMemoria>().Activar(gameObject);
        }
    }
}
