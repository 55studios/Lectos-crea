using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehiculoEstrella : MonoBehaviour
{

    public Transform encuentro;


    private void OnEnable()
    {
        transform.DOMove(encuentro.position, 3.2f).SetDelay(1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Mover()
    {
        Sequence secuencia = DOTween.Sequence();
        secuencia.Append(GetComponent<SpriteRenderer>().DOColor(Color.yellow, 1f));
        secuencia.Append(transform.DOMoveY(10, 0.8f));
    }
}
