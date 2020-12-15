using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehiculoAsteroide : MonoBehaviour
{
    [SerializeField]
    Sprite roto1;
    [SerializeField]
    Sprite roto2;

    public Transform encuentro;
    bool moviendo;

    /*private void OnEnable()
    {
        print("hijos " + transform.childCount);
        if (transform.childCount == 3)
        {
            transform.DOMove(encuentro.position, 3f);
        } else
        {
            GameObject.FindGameObjectWithTag("AnimadorVehiculos").GetComponent<AnimarVehiculos>().AsteroideVacio();
            //Destroy(gameObject);
        }        
    }*/

    void Mover ()
    {
        if (moviendo)
        {
            transform.Find("1").GetComponent<SpriteRenderer>().sprite = roto1;
            transform.Find("2").GetComponent<SpriteRenderer>().sprite = roto2;
            Destroy(gameObject, 0.8f);
        } else
        {
            //print("hijos " + transform.childCount);
            if (transform.childCount == 3)
            {
                
                transform.DOMove(encuentro.position, 3f);
                moviendo = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("AnimadorVehiculos").GetComponent<AnimarVehiculos>().AsteroideVacio();
                //Destroy(gameObject);
            }
        }
        
    }
}
