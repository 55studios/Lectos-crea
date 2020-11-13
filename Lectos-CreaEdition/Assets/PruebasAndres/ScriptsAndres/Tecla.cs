using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tecla : MonoBehaviour
{
    //Text t;
    //public char c;
    // Start is called before the first frame update
    void Start()
    {
        //t = GameObject.FindWithTag("Texto").GetComponent<Text>();
    }

    public void Escribir ()
    {
        CheckText t = GameObject.FindWithTag("Reproductor").GetComponent<CheckText>();
        string c = transform.Find("Text").GetComponent<Text>().text;//.ToCharArray()[0];
        t.GetComponent<CheckText>().AgregarChar(c);
    }
}
