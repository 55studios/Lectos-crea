using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerAnimations : MonoBehaviour
{
    public List<ScaleAnimationInOut> animationsScales;

    public void OnAnimationOut() {
        for (int i = 0; i < animationsScales.Count; i++) {
            animationsScales[i].OutAnimation();
        }
    }
}
