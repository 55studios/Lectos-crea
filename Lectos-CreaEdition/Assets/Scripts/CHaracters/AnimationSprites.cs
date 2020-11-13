using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationSprites : MonoBehaviour {

    [Tooltip("Basado en tiempo real")]
    public float frameRate;
    public bool isUi;
    public Sprite[] animationsSprites;
    public Texture[] animationTextures;
    private MeshRenderer shderTexture;
    private Image _imageRenderer;
    private bool waveActive = true;
	void Start ()
    {
        if (!isUi) {
            shderTexture = GetComponent<MeshRenderer>();
            StartCoroutine(LoopAnimation());
        }
        else {
            _imageRenderer = GetComponent<Image>();
            StartCoroutine(LoopAnimationSprites());
        }
        
		
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
                yield return new WaitForSeconds(frameRate);
            }
        }
    }

    IEnumerator LoopAnimationSprites() {
        while (waveActive) {

            for (int i = 0; i < animationsSprites.Length; i++) {
                _imageRenderer.sprite = animationsSprites[i];
                if (i == animationsSprites.Length) {
                    i = 0;
                }
                yield return new WaitForSeconds(frameRate);
            }
        }
    }
}
