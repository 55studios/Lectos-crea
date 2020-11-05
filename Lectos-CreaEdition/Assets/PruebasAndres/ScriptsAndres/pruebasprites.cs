using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebasprites : MonoBehaviour
{
    public Sprite imagen;
    public Sprite[] imagenes;
    string t;

    // Start is called before the first frame update
    void Start()
    {
        t = "tigre";
        imagenes = Resources.LoadAll<Sprite>("Tigre/" + t);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
