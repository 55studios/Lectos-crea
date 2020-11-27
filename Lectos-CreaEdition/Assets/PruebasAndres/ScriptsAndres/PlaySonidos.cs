using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySonidos : MonoBehaviour
{

    public AudioClip[] sonidos;
    public Sonido[] elementosSonido;
    AudioSource AS;
    public int audioActual;

    int[] ordenSonidos;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        AS = GetComponent<AudioSource>();
        ordenSonidos = new int[sonidos.Length];
        SetOrdenSonidos(ordenSonidos);
        audioActual = ordenSonidos[index];
    }

    private void OnMouseUp()
    {
        AS.clip = sonidos[audioActual];
        if (Input.GetMouseButtonUp(0))
        {
            AS.Stop();
            AS.Play();
            foreach (Sonido so in elementosSonido)
            {
                so.clickeable = true;
            }
        }
    }

    public void CambiarAudio ()
    {
        if (index < 4)
        {
            index++;
            if (ordenSonidos.Length > 2 )
            {
                audioActual = ordenSonidos[index];
                AS.clip = sonidos[audioActual];
                foreach (Sonido so in elementosSonido)
                {
                    so.clickeable = false;
                }
            } else
            {
                if (index == 1)
                {
                    audioActual = ordenSonidos[index];
                    AS.clip = sonidos[audioActual];
                    foreach (Sonido so in elementosSonido)
                    {
                        so.clickeable = false;
                    }
                }
            }
        }
    }

    void SetOrdenSonidos (int[] lista)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            ordenSonidos[i] = i;
        }
        System.Array.Sort(lista, RandomSort);
        System.Array.Sort(lista, RandomSort);
        System.Array.Sort(lista, RandomSort);
    }

    int RandomSort(int a, int b)
    {
        return Random.Range(-1, 2);
    }
}
