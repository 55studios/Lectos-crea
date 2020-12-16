using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDelay : MonoBehaviour
{
    public float _Delay;
    [Range(0,3)]
    public int index;
    public GameObject[] m_Panel;

    public void StartDelay() {
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(_Delay);
        m_Panel[index].SetActive(true);
    }
}
