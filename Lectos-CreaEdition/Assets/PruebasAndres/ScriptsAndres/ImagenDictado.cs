using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenDictado : MonoBehaviour
{
    public Sprite[] frames;
    int frame = 0;

    public void Animar()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        InvokeRepeating("Animacion", 0, 0.1f);
    }

    void Animacion ()
    {
        if (frames.Length > 1)
        {
            GetComponent<SpriteRenderer>().sprite = frames[frame];
            frame++;
            if (frame == frames.Length - 1)
            {
                frame = 0;
            }
        }        
    }

    public void Destruir ()
    {
        Destroy(gameObject, 3f);
    }

    private void OnMouseUp()
    {
        GameObject.FindGameObjectWithTag("Organizador").GetComponent<CheckDictado>().RepetirSonido();
    }
}
