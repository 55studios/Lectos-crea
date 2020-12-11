using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDelay : MonoBehaviour
{
    public float _Delay;
    public GameObject panel;

    public void StartDelay() {
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(_Delay);
        panel.SetActive(true);
    }
}
