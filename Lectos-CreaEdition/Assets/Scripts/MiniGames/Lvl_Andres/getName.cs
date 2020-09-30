using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour {

    public string SortingLayerName = "Default";
    public int SortingOrder = 0;

    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
    }

    // Use this for initialization
    void Start () {
        transform.GetComponent<TextMesh>().text = PlayerPrefs.GetString("Name");
    }
}
