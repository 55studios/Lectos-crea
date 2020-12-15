using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichaRompecabezas : MonoBehaviour
{

    private void OnDestroy()
    {
        GameObject.FindWithTag("Organizador").GetComponent<PuzzleCompleto>().SumarRespuesta();
    }
}
