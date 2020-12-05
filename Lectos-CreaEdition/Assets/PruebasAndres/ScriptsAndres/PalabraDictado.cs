using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PalabraDictado : MonoBehaviour
{
    int letraActual = 0;

    public void LetraCorrecta ()
    {
        GameObject hijo = transform.GetChild(letraActual).gameObject;
        hijo.transform.DOScale(hijo.transform.localScale * 1.5f, 0.5f);
        hijo.GetComponent<SpriteRenderer>().DOFade(255f, 0.5f);
        letraActual++;
    }
}