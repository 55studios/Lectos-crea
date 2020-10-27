using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{
    public ScriptableScene SC;
    public GameObject activadorPrefab;
    public GameObject receptorPrefab;
    public GameObject receptorTextoPrefab;
    public GameObject receptorMemoriaPrefab;

    Organizador Or;
    GameObject[] receptoresCreados;
    int posicionListaReceptores;
    int puntaje;
    int maxPuntaje;
    string nombreMinijuego;
    bool creado;

    public void Cargar (string s)
    {
        puntaje = 0;
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        nombreMinijuego = s;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!creado)
        {
            creado = true;
            maxPuntaje = SC.puntosLogrables;
            Or = GameObject.FindGameObjectWithTag("Organizador").GetComponent<Organizador>();
            switch (SC.tipoMinijuego)
            {
                case 1: //drag&drop                
                    Transform[] activ = Or.activadores;
                    Transform[] recep = Or.receptores;
                    CreateSprites(activ, SC.activadores, activadorPrefab, false);
                    CreateSprites(recep, SC.receptores, receptorPrefab, true);
                    break;
                case 2: //escribir palabra
                    Transform[] recepText = Or.receptores;
                    CreateSpritesText(recepText, SC.receptores, receptorTextoPrefab);
                    break;
                case 3: //memoria
                    Transform[] recepMemo = Or.receptores;
                    CreateSpritesMemoria(recepMemo, SC.activadores, SC.receptores, receptorMemoriaPrefab);
                    break;
                default:
                    print("No tipo de minijuego");
                    break;
            }
        }
    }

    void CreateSprites (Transform[] posiciones, Sprite[] imagenes, GameObject prefab, bool b)
    {
        System.Array.Sort(posiciones, RandomSort);
        if (posiciones.Length > 1)
        {
            for (int i = 0; i < posiciones.Length; i++)
            {
                GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
                elemento.GetComponent<SpriteRenderer>().sprite = imagenes[i];
                elemento.name = imagenes[i].name;
                elemento.GetComponent<Respuesta>().respuesta = i;
            }
        } else
        {
            receptoresCreados = new GameObject[imagenes.Length];
            for (int i = 0; i < imagenes.Length; i++)
            {
                GameObject elemento = Instantiate(prefab, posiciones[0].position, Quaternion.identity);
                elemento.GetComponent<SpriteRenderer>().sprite = imagenes[i];
                elemento.name = imagenes[i].name;
                elemento.GetComponent<Respuesta>().respuesta = i;
                receptoresCreados[i] = elemento;
                if (i > 0)
                {
                    elemento.SetActive(false);
                }
            }
            posicionListaReceptores = 0;
        }
    }

    void CreateSpritesText (Transform[] posiciones, Sprite[] imagenes, GameObject prefab)
    {
        System.Array.Sort(posiciones, RandomSort);
        receptoresCreados = new GameObject[imagenes.Length];
        for (int i = 0; i < imagenes.Length; i++)
        {
            GameObject elemento = Instantiate(prefab, posiciones[0].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = imagenes[i];
            elemento.name = imagenes[i].name;
            elemento.GetComponent<RespuestaTexto>().respuesta = SC.respuestasTexto[i];
            receptoresCreados[i] = elemento;
            if (i > 0)
            {
                elemento.SetActive(false);
            }
        }
        posicionListaReceptores = 0;
    }

    void CreateSpritesMemoria (Transform[] posiciones, Sprite[] imagenes1, Sprite[] imagenes2, GameObject prefab)
    {
        int n = 0;
        System.Array.Sort(posiciones, RandomSort);
        for (int i = 0; i < imagenes1.Length; i++)
        {
            if (n != 0)
            {
                n++;
            }
            GameObject elemento = Instantiate(prefab, posiciones[n].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = imagenes1[i];
            elemento.GetComponent<Respuesta>().respuesta = i;
            elemento.GetComponent<Memoria>().checker = Or.gameObject;
            n++;
            GameObject elemento2 = Instantiate(prefab, posiciones[n].position, Quaternion.identity);
            elemento2.GetComponent<SpriteRenderer>().sprite = imagenes2[i];
            elemento2.GetComponent<Respuesta>().respuesta = i;
            elemento2.GetComponent<Memoria>().checker = Or.gameObject;
        }
    }


    int RandomSort(Transform a, Transform b)
    {
        return Random.Range(-1, 2);
    }

    public void RespuestaCorrecta ()
    {
        print("correcto!!!!!");
        puntaje++;
        if (receptoresCreados != null && posicionListaReceptores < receptoresCreados.Length - 1)
        {
            posicionListaReceptores++;
            receptoresCreados[posicionListaReceptores].SetActive(true);
        }
        if (puntaje == maxPuntaje)
        {
            puntaje = 0;
            print("Terminado el juego" + nombreMinijuego);
            SceneManager.UnloadSceneAsync(nombreMinijuego);
            SC = null;
            Or = null;
            maxPuntaje = 0;
            creado = false;
        }
    }
}
