using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehiculoTren : MonoBehaviour
{
    [SerializeField]
    float[] puntosEnX;
    int indexAnim;

    void Start()
    {
        indexAnim = 1;
        transform.DOMoveX(puntosEnX[0], 3f).SetEase(Ease.InOutCubic);
        GetComponent<AudioSource>().PlayDelayed(1f);
    }

    public void Mover()
    {
        GetComponent<AudioSource>().Play();
        transform.DOMoveX(puntosEnX[indexAnim], 2f).SetEase(Ease.InOutCubic);
        indexAnim++;
    }
}