using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFace : MonoBehaviour {

    public Texture[] animationFaces;

    private MeshRenderer ShaderMain;
    private float countTime;
    private float randomTime;
    private bool active;
    
    void Start () {
        countTime = 0;
        ShaderMain = GetComponent<MeshRenderer>();
        ShaderMain.material.SetTexture("_MainTex", animationFaces[0]);
        RandomTimeSelection();
        active = false;
    }

    void Update()
    {
        countTime += Time.deltaTime;
        //print(countTime);
        if (!active)
        {
            if (countTime >= randomTime)
                StartCoroutine(ChangeFace());

            else
                ShaderMain.material.SetTexture("_MainTex", animationFaces[0]);
        }
        
    }

    void RandomTimeSelection()
    {
        randomTime = Random.Range(0.9f, Random.Range(1.2f, 2.5f));
   
    }

    IEnumerator ChangeFace()
    {
        active = true;
        countTime = 0;
        ShaderMain.material.SetTexture("_MainTex", animationFaces[1]);
        RandomTimeSelection();
        yield return new WaitForSeconds(0.2f);
        active = false;
        yield return null;
    }
}
