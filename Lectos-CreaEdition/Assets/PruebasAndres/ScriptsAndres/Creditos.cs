using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Creditos : MonoBehaviour
{
    [SerializeField]
    float distancia;
    [SerializeField]
    float tiempo;
    [SerializeField]
    float demora;
    Tween scroll;
    // Start is called before the first frame update
    void Start()
    {
        scroll = GetComponent<RectTransform>().DOMoveY(distancia, tiempo).SetEase(Ease.Linear).SetDelay(demora);
    }
}
