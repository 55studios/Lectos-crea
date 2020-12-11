using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    [SerializeField]
    TMP_Text textoTiempo;
    [SerializeField]
    TMP_Text tiempoEnVivo;
    float tiempo;
    float t;
    bool terminado = true;
    [SerializeField]
    GameObject[] estrellasFinal = new GameObject[3];
    float[] Tiempos;

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
        string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f0");
        tiempoEnVivo.text = minutos + ":" + segundos;
    }

    public void Iniciar (float[] tiempos)
    {
        Tiempos = tiempos;
        tiempo = 0;
        tiempo = Time.time;
        terminado = false;
        PrenderEstrellas(false);
    }

    public void Terminar ()
    {
        terminado = true;
        string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f0");
        print("segundos = " + t);
        textoTiempo.text = minutos + ":" + segundos;
        PrenderEstrellas(true);
    }

    void PrenderEstrellas(bool terminar)
    {
        if (terminar)
        {
            for (int i = 0; i < estrellasFinal.Length; i++)
            {
                if (t < Tiempos[i])
                {
                    estrellasFinal[i].SetActive(true);
                }
            }
        } else
        {
            foreach (GameObject estrella in estrellasFinal)
            {
                estrella.SetActive(false);
            }
        }
    }
}
