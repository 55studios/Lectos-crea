using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationSprites : MonoBehaviour {

    [Tooltip("Basado en tiempo real")]
    public float frameRate;
    public bool isUi;
    public bool isLecto;
    public Sprite[] animationsSprites;
    public Texture[] animationTextures;
    private MeshRenderer shderTexture;
    private Image _imageRenderer;
    private SpriteRenderer _SpriteRenderer;
    private bool waveActive = true;

	void Start ()
    {
        if (!isUi) {
            shderTexture = GetComponent<MeshRenderer>();
            StartCoroutine(LoopAnimation());
        }
        else {
            if (GetComponent<Image>() != null) {
                _imageRenderer = GetComponent<Image>();
                StartCoroutine(LoopAnimationImage());
            }
            else {
                _SpriteRenderer = GetComponent<SpriteRenderer>();
                StartCoroutine(LoopAnimationSprites());
            }
        }
	}
    IEnumerator LoopAnimation()
    {
        while (waveActive)
        {
            if (isLecto) {
                for (int i = 0; i < animationTextures.Length; i++) {
                    shderTexture.material.SetTexture("_MainTex", animationTextures[i]);
                    if (i == animationTextures.Length - 1) {
                        i = 0;
                    }
                    yield return new WaitForSeconds(frameRate);
                }
            }
            else {
                for (int i = 0; i < animationTextures.Length; i++) {
                    shderTexture.material.SetTexture("_Texture_Tv", animationTextures[i]);
                    if (i == animationTextures.Length - 1) {
                        i = 0;
                    }
                    yield return new WaitForSeconds(frameRate);
                }
            }
        }
    }
    IEnumerator LoopAnimationImage() {
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
    IEnumerator LoopAnimationSprites() {
        while (waveActive) {
            for (int i = 0; i < animationsSprites.Length; i++) {
                _SpriteRenderer.sprite = animationsSprites[i];
                if (i == animationsSprites.Length) {
                    i = 0;
                }
                yield return new WaitForSeconds(frameRate);
            }
        }
    }
}
