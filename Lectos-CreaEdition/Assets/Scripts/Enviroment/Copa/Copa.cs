using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copa : MonoBehaviour {

    public ParticleSystem twinkleOne;
    public ParticleSystem twinkleTwo;
    private GameManager gameManager;

    void Start () {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("TwinclesOne", 1, 1.5f);
        InvokeRepeating("TwinclesTwo", 1.3f, 1.1f);
        if (gameManager.trofeo)
            transform.gameObject.SetActive(true);
        else
            transform.gameObject.SetActive(false);
    }
    void TwinclesOne()
    {
        twinkleOne.Play();
    }
    void TwinclesTwo()
    {
        twinkleTwo.Play();
    }
}
