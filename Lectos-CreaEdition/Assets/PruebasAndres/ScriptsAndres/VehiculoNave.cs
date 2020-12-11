using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehiculoNave : MonoBehaviour
{
    public Transform encuentro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.DOMove(encuentro.position, 3f);
    }

    void Mover ()
    {
        //Destroy(gameObject, 2f);
        GetComponent<DOTweenPath>().DOPlay();
    }
}