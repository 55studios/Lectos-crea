using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDictado : MonoBehaviour
{
    [SerializeField]
    GameObject teclado;

    public GameObject[] respuestas;
    public GameObject[] palabras;
    public AudioClip[] sonidos;
    string[] letras;
    int[] orden;
    int index;
    int letrasCorrectas;
    AudioSource AS;

    public void Iniciar()
    {
        teclado.SetActive(true);
        AS = GetComponent<AudioSource>();
        foreach (GameObject gob in respuestas)
        {
            string nombre = gob.name;
            string[] letrasEnRespuesta = new string[nombre.Length];
            char[] nombreChar = nombre.ToCharArray();
            for (int i = 0; i < nombre.Length; i++)
            {
                letrasEnRespuesta[i] = nombreChar[i].ToString();
            }
            /*foreach (string ch in letrasEnRespuesta)
            {
                string nombrechar = ch;
                GameObject temp = teclado.transform.Find(nombrechar).gameObject;
                temp.transform.Find("letra").gameObject.SetActive(true);
                temp.GetComponent<Letra>().enabled = true;                
                temp.transform.Find("fondo").GetComponent<SpriteRenderer>().color = Color.white;
            }*/
        }
        letrasCorrectas = 0;
        index = 0;
        orden = new int[respuestas.Length];
        for (int i = 0; i < orden.Length; i++)
        {
            orden[i] = i;
        }
        System.Array.Sort(orden, RandomSort);
        System.Array.Sort(orden, RandomSort);
        System.Array.Sort(orden, RandomSort);
        respuestas[orden[index]].SetActive(true);
        palabras[orden[index]].SetActive(true);
        letras = Convertir(respuestas[orden[index]].name.ToCharArray(), letras);

        AS.clip = sonidos[orden[index]];
        AS.Play();
    }

    public void CompararLetras(string presionado)
    {
        if (presionado == letras[letrasCorrectas])
        {
            letrasCorrectas++;
            palabras[orden[index]].GetComponent<PalabraDictado>().LetraCorrecta();
            if (letrasCorrectas == letras.Length)
            {
                AudioSource auTemp = respuestas[orden[index]].GetComponent<AudioSource>();
                auTemp.clip = sonidos[orden[index]];
                auTemp.PlayDelayed(0.5f);
                respuestas[orden[index]].GetComponent<ImagenDictado>().Animar();
                respuestas[orden[index]].GetComponent<ImagenDictado>().Destruir();
                Destroy(palabras[orden[index]], 3f);
                CambiarImagen();
                if (index < respuestas.Length -1)
                {
                    index++;
                    AS.clip = sonidos[orden[index]];
                    Invoke("SiguienteImagen", 3f);
                }                                        
            }
        } else
        {
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().Error();
        }
    }

    void CambiarImagen()
    {
        //print("se llamo");
        GameObject controlador = GameObject.FindWithTag("GameController");
        controlador.GetComponent<CreateLevel>().RespuestaCorrecta(palabras[orden[index]].transform.position);
    }

    void SiguienteImagen ()
    {
        index--;
        AS.Play();        
        index++;
        respuestas[orden[index]].SetActive(true);
        palabras[orden[index]].SetActive(true);
        letrasCorrectas = 0;
        letras = Convertir(respuestas[orden[index]].name.ToCharArray(), letras);
    }

    string[] Convertir(char[] listachar, string[] listaString)
    {
        string[] temporalString = new string[listachar.Length];
        for (int i = 0; i < listachar.Length; i++)
        {
            temporalString[i] = listachar[i].ToString();
        }
        listaString = temporalString;
        return listaString;
    }

    int RandomSort(int a, int b)
    {
        return Random.Range(-1, 2);
    }

    void SiguienteSonido ()
    {        
        AS.PlayDelayed(2f);
    }

    public void RepetirSonido ()
    {
        AS.Play();
    }
}
