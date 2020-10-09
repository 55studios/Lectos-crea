using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour {

    private Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(AnimationPlay());
        
	}

    IEnumerator AnimationPlay()
    {
        yield return new WaitForSeconds(2.51f);
        anim.SetTrigger("Play");
        yield return new WaitForSeconds(2.8f);
        anim.SetTrigger("Play");
    }

}
