using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour {

    Vector3 rotationEuler;
    int value = 150;

    // Use this for initialization
    void Start () {

        Invoke("otherDirection", 1f);
    }
	
	// Update is called once per frame
	void Update () {
        rotationEuler += Vector3.forward * value * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationEuler);
        
    }

    void otherDirection() {
        value = -150;
    }
}
