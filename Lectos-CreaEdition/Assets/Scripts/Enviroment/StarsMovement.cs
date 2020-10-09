using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMovement : MonoBehaviour {

    public float speed;
    public float timeOfDestruction;

	void Update () {

        transform.Translate(-speed,-speed,0);
        Destroy(gameObject,timeOfDestruction);
		
	}
}
