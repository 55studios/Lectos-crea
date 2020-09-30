using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

    private ParticleSystem fireworks;
    private float countTime = 0;
    private float randomTime;
    private bool active = false;

	void Start () {
        fireworks = GetComponent<ParticleSystem>();
        RandomExplotion();
    }
	
	void Update () {

        countTime += Time.deltaTime;
        if (!active)
        {
            if (countTime >= randomTime)
                StartCoroutine(Explotion());

        }

    }

    void RandomExplotion(){

        randomTime = Random.Range(1, Random.Range(1.5f, 2));
    }


    IEnumerator Explotion() {
        active = true;
        countTime = 0;
        fireworks.Play();
        RandomExplotion();
        yield return new WaitForSeconds(0.5f);
        active = false;
        yield return null;

    }
}
