using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour
{
    public GameObject checker;
    public bool activado;
    public AudioSource audioS;
    public AudioClip miSonido;

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) && !activado)
        {
            checker.GetComponent<CheckMemoria>().Activar(gameObject);
            if (audioS != null && miSonido != null)
            {
                audioS.Stop();
                audioS.clip = miSonido;
                audioS.Play();
            }
        }
    }
}
