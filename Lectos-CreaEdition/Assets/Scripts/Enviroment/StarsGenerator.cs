using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsGenerator : MonoBehaviour {

    public Vector2 RandomPositionA = new Vector2(80, 37);
    public Vector2 RandomPositionB = new Vector2(100, 130);
    public GameObject[] stars;  
    public float intervaleTime = 5f;

	void Start () {

        InvokeRepeating("StarsGeneratorTime", intervaleTime,intervaleTime);
	}
	
	

    void StarsGeneratorTime(){

        
        Vector2 postionStar = new Vector2(Random.Range(RandomPositionA.x, RandomPositionB.x), Random.Range(RandomPositionA.y, RandomPositionB.y));
        int randomStars = Random.Range(0, stars.Length);

        Instantiate(stars[randomStars], postionStar, transform.rotation);

    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(RandomPositionA.x, RandomPositionA.y,0), 2);
        Gizmos.DrawSphere(new Vector3(RandomPositionB.x, RandomPositionB.y, 0), 2);
        Gizmos.DrawLine(new Vector3(RandomPositionA.x, RandomPositionA.y,0), new Vector3(RandomPositionB.x, RandomPositionB.y, 0));
    }
}
