using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float timeOfDestruction;

    void Start () {

        Invoke("DestroyElement", timeOfDestruction);
	}

    void DestroyElement()
    {
        Destroy(gameObject);
    }
}
