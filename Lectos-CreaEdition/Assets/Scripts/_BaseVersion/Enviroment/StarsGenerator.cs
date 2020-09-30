using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsGenerator : MonoBehaviour {

    public GameObject[] stars;  
    public float intervaleTime = 5f;

	void Start () {

        InvokeRepeating("StarsGeneratorTime", intervaleTime,intervaleTime);
	}
	
	

    void StarsGeneratorTime(){

        
        Vector2 postionStar = new Vector2(Random.Range(0,80), 37);
        int randomStars = Random.Range(0, stars.Length);

        Instantiate(stars[randomStars], postionStar, transform.rotation);

    }
}
