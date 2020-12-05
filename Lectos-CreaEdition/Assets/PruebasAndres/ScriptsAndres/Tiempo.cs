using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    [SerializeField]
    TMP_Text textoTiempo;
    float tiempo;
    float t;
    bool terminado = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (terminado)
            return;
        t = Time.time - tiempo;
    }

    public void Iniciar ()
    {
        tiempo = 0;
        tiempo = Time.time;
        terminado = false;
    }

    public void Terminar ()
    {
        terminado = true;
        string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f0");
        print("segundos = " + t);
        textoTiempo.text = minutos + ":" + segundos;
    }
}
