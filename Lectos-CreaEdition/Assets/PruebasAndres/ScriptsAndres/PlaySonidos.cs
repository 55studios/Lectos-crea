using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySonidos : MonoBehaviour
{

    public AudioClip[] sonidos;
    AudioSource AS;
    public int audioActual;
    // Start is called before the first frame update
    void Start()
    {
        audioActual = 0;
        AS = GetComponent<AudioSource>();
        AS.clip = sonidos[0];
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            AS.Stop();
            AS.Play();
        }
    }

    public void CambiarAudio ()
    {
        audioActual++;
        AS.clip = sonidos[audioActual];
    }
}
