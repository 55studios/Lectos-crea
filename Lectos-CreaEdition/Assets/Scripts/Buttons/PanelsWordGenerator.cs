using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsWordGenerator : MonoBehaviour {

    public Animator panels;
    public Animator ballControlAnim;
    public Animator imagesAnim;
    public GameObject taril;
    public AudioSource soundBoing;
    public AudioSource soundBoingShort;

	void Start () {

        taril.GetComponent<TrailRenderer>().enabled = true;
        ballControlAnim.SetBool("Out",false);
        soundBoing.Play();
		
	}

    public void NextPabel()
    {
        panels.SetTrigger("Next");
        ballControlAnim.SetBool("Out", true);
        taril.GetComponent<TrailRenderer>().enabled = false;
        imagesAnim.SetTrigger("Init");
    }
    public void BackPabel()
    {
        panels.SetTrigger("Back");
        //ballControlAnim.SetBool("Out", false);
        taril.GetComponent<TrailRenderer>().enabled = true;
        ballControlAnim.SetTrigger("Again");
        soundBoingShort.Play();
        
    }

    public void Again()
    {
        ballControlAnim.SetTrigger("Again");
        soundBoingShort.Play();
    }
    public void PlayGame()
    {
        print("LoadScenenow");
    }

    public void AgainImage()
    {
        imagesAnim.SetTrigger("Reinit");
        imagesAnim.SetTrigger("Start");
    }
}
