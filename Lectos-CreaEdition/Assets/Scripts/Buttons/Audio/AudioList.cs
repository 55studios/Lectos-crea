using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour {

    public AudioClip[] dialog;
    private AudioSource audioS;
    int countClips;

    private void Start()
    {
        countClips = 0;
        audioS = GetComponent<AudioSource>();
    }

    public void NextAudio()
    {
        if (countClips < dialog.Length)
        {
            audioS.clip = dialog[countClips];
            audioS.Play();
            countClips++;
        }
        else
        {
            return;     
        }
        
    }

}
