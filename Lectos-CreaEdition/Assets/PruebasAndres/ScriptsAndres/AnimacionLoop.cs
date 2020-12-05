using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionLoop : MonoBehaviour
{
    [SerializeField]
    Sprite[] frames;
    int frame = 0;
    // Start is called before the first frame update
    private void OnEnable()
    {
        InvokeRepeating("Animar", 0, 0.1f);
        print("llamada animacion barra");
    }

    private void Update()
    {
        print(frame);
    }

    void Animar()
    {
        GetComponent<SpriteRenderer>().sprite = frames[frame];
        frame++;
        if (frame == frames.Length - 1)
        {
            frame = 0;
        }
    }
}
