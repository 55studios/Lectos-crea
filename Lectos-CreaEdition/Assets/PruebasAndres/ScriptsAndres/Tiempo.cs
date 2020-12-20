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
    int tempMoon;
    public HandlerLevelsData[] dataMoons;
    CreateLevel controlador;
    public int TempStars = 0;
    private void Start() {
        //PlayerPrefs.DeleteAll();
        controlador = GetComponent<CreateLevel>();
    }

    void Update()
    {
        if (terminado)
            return;
        t = Time.time - tiempo;
        /*string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f0");
        tiempoEnVivo.text = minutos + ":" + segundos;*/
        int minutos = Mathf.FloorToInt(t / 60f);
        int segundos = Mathf.FloorToInt(t - minutos * 60);
        string tiempoTexto = string.Format("{0:0}:{1:00}", minutos, segundos);
        tiempoEnVivo.text = tiempoTexto;
    }

    public void Iniciar (float[] tiempos)
    {
        Tiempos = tiempos;
        tiempo = 0;
        tiempo = Time.time;
        terminado = false;
        PrenderEstrellas(false);
        TempStars = 0;
    }

    public void Terminar ()
    {
        terminado = true;
        /*string minutos = ((int)t / 60).ToString();
        string segundos = (t % 60).ToString("f0");
        print("segundos = " + t);
        textoTiempo.text = minutos + ":" + segundos;*/
        int minutos = Mathf.FloorToInt(t/60f);
        int segundos = Mathf.FloorToInt(t - minutos * 60);
        string tiempoTexto = string.Format("{0:0}:{1:00}", minutos, segundos);
        textoTiempo.text = tiempoTexto;
        PrenderEstrellas(true);
    }

    void PrenderEstrellas(bool terminar)
    {
        if (terminar)
        {
            for (int i = 0; i < estrellasFinal.Length; i++)
            {
                if (t < Tiempos[i]){
                    TempStars++;
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

    public void SetMoonhandler(int moonData) {
        tempMoon = moonData;
    }

    public void Guardar (int Lvl, int lenghtLvl){
        switch (tempMoon) {
            case 0:
                dataMoons[0].WriteLevelData(MoonsLevel.MoonOne, Lvl, true, TempStars, t, t);
                if (lenghtLvl < Lvl) {
                    if (dataMoons[0]._LevelsData[Lvl + 1].isActive) {
                        print("Data is saved");
                    }
                    else {
                        dataMoons[0].WriteLevelData(MoonsLevel.MoonOne, Lvl + 1, true, 0, 0, 0);
                    }
                }
                break;
            case 1:
                dataMoons[1].WriteLevelData(MoonsLevel.MoonTwo, Lvl, true, TempStars, t, t);
                if (lenghtLvl < Lvl) {
                    if (dataMoons[1]._LevelsData[Lvl + 1].isActive) {
                        print("Data is saved");
                    }
                    else {
                        dataMoons[1].WriteLevelData(MoonsLevel.MoonTwo, Lvl + 1, true, 0, 0, 0);
                    }
                }
                
                break;
            case 2:
                dataMoons[2].WriteLevelData(MoonsLevel.MoonTree, Lvl, true, TempStars, t, t);
                if (lenghtLvl < Lvl) {
                    if (dataMoons[2]._LevelsData[Lvl + 1].isActive) {
                        print("Data is saved");
                    }
                    else {
                        dataMoons[2].WriteLevelData(MoonsLevel.MoonTree, Lvl + 1, true, 0, 0, 0);
                    }
                }    
                break;
        }

    }
}
