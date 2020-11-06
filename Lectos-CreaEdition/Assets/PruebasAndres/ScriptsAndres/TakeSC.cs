using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSC : MonoBehaviour
{
    public ScriptableScene scri;

    public void Asignar (CreateLevel CL)
    {
        CL.SC = scri;
    }
}
