using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehiculoNave : MonoBehaviour
{
    public Transform encuentro;
    bool moviendo;
    bool salir;
    bool adentro;
    TweenCallback callBack;

    private void Update()
    {
        if (salir && adentro)
        {
            GetComponent<DOTweenPath>().DOPlay();
            adentro = false;
        }
    }

    /*private void OnEnable()
    {
        transform.DOMove(encuentro.position, 3f);
    }*/

    void Mover ()
    {
        if (moviendo)
        {
            //Destroy(gameObject, 2f);         
            //GetComponent<DOTweenPath>().DOPlay();
            salir = true;
        } else
        {
            transform.DOMove(encuentro.position, 3f).OnComplete(()=>Arribo());
            moviendo = true;
        }
    }

    void Arribo ()
    {
        adentro = true;
    }
}