using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSprites : MonoBehaviour {

    public Texture[] animationTextures;
    private MeshRenderer shderTexture;
    private bool waveActive = true;
	void Start ()
    {
        shderTexture = GetComponent<MeshRenderer>();
        StartCoroutine(LoopAnimation());
		
	}

    IEnumerator LoopAnimation()
    {
        while (waveActive)
        {
  
            for (int i = 0; i < animationTextures.Length; i++)
            {
                shderTexture.material.SetTexture("_Texture_Tv", animationTextures[i]);
                if (i == animationTextures.Length - 1)
                {
                    i = 0;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
