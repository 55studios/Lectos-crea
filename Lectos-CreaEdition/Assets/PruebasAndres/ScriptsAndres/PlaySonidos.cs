using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySonidos : MonoBehaviour
{

    public AudioClip[] sonidos;
    public Sonido[] elementosSonido;
    AudioSource AS;
    public int audioActual;
    // Start is called before the first frame update
    void Start()
    {
        audioActual = 0;
        AS = GetComponent<AudioSource>();
        
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
        if (audioActual < 4)
        {
            audioActual++;
            AS.clip = sonidos[audioActual];
            foreach (Sonido so in elementosSonido)
            {
                so.clickeable = false;
            }
        }
    }
}
