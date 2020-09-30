using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour {

    public float delay;

    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        Invoke("DelaySound", delay);
	}

    void DelaySound()
    {
        audioSource.Play();
    }
}
