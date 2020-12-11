using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTutorialController : MonoBehaviour
{
    public ScaleAnimationInOut[] animationsIn;

    void Start()
    {
        
    }

    private void OnEnable() {
        for (int i = 0; i < animationsIn.Length; i++) {
            animationsIn[i].InAnimation();
        }
    }
}
