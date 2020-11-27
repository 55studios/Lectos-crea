using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letra : MonoBehaviour
{
    Vector3 escala;
    SpriteRenderer letra;
    SpriteRenderer fondo;
    CheckDictado checker;

    void Start()
    {
        checker = GameObject.FindGameObjectWithTag("Organizador").GetComponent<CheckDictado>();
        char[] convertir = transform.name.ToCharArray();
        string letraAComparar = convertir[0].ToString();
        escala = transform.localScale;
        letra = transform.Find("letra").GetComponent<SpriteRenderer>();
        fondo = transform.Find("fondo").GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        transform.localScale = escala * 1.2f;
        letra.sortingOrder = 4;
        fondo.sortingOrder = 3;
    }

    private void OnMouseUp()
    {
        GetComponent<AudioSource>().Play();
        transform.localScale = escala;
        letra.sortingOrder = 3;
        fondo.sortingOrder = 2;
        checker.CompararLetras(name);
    }
}
