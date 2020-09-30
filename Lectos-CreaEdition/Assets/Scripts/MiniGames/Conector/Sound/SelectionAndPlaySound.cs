using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAndPlaySound : MonoBehaviour {

    public AudioClip[] clips;
    [HideInInspector]
    public int numberCLip = 0;
    private AudioSource audioSource;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}

    public void SelectSoundAndPlay()
    {
        audioSource.clip = clips[numberCLip];
        audioSource.Play();
    }
}
