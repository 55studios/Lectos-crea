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

    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.DOMove(encuentro.position, 3f);
    }

    void Mover ()
    {
        transform.Find("1").GetComponent<SpriteRenderer>().sprite = roto1;
        transform.Find("2").GetComponent<SpriteRenderer>().sprite = roto2;
        Destroy(gameObject, 0.8f);
    }
}
