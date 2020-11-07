using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.SceneManagement;

public class ChangeTargetC : MonoBehaviour {

    public string nextScene;

    private Transform rocket;
    private Transform lectosName;
    private ProCamera2D influenceChange;
    private CameraTarget camRocket;
    private CameraTarget camlectosN;
    private ProCamera2DTransitionsFX _fx;
    public GameObject lectos;
    private Animator animRobot;
    private MeshRenderer onTv;
    private bool TurnOnTv;
    private float countDown = 10;

    private ProCamera2DShake shakeRocket;
    private float timeCount;

    void Start()
    {
        influenceChange = GetComponent<ProCamera2D>();
        _fx = GetComponent<ProCamera2DTransitionsFX>();
        shakeRocket = GetComponent<ProCamera2DShake>();
        rocket = GameObject.Find("Rocket").transform;
        lectosName = GameObject.Find("Lectos").transform;
        camRocket = influenceChange.AddCameraTarget(rocket, 1, 1);
        camlectosN = influenceChange.AddCameraTarget(lectosName, 0, 0);
        _fx.TransitionEnter();
        animRobot = GameObject.Find("LectoRobot").GetComponent<Animator>();
        onTv = lectos.GetComponent<MeshRenderer>();
        onTv.material.SetFloat("_TimeLine", 10);
        //Invoke("RobotTime", 14);
       StartCoroutine (timeSwitch());
        StartCoroutine(ShakeRocketTakeoff());
    }

    IEnumerator timeSwitch()
    {
        yield return new WaitForSeconds(12);
        influenceChange.AdjustCameraTargetInfluence(camRocket,0,0, 1);
        influenceChange.AdjustCameraTargetInfluence(camlectosN, 1, 1, 1);
        yield return new WaitForSeconds(2);
        animRobot.SetTrigger("ActivateIntro");
        yield return new WaitForSeconds(1.2f);
        TurnOnTv = true;
        yield return new WaitForSeconds(6);
        _fx.TransitionExit();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator ShakeRocketTakeoff()
    {
        yield return new WaitForSeconds(2.1f);
        while (timeCount < 5.30f )
        {
            shakeRocket.ShakeUsingPreset("ShakeRocket");
            yield return new WaitForSeconds(0.3f);

        }
    }

    private void Update()
    {
        timeCount = +Time.time;
        

        if (TurnOnTv)
        {
            countDown =- 0.001f;
            if (countDown <= 0)
            {
                countDown = 0;
            }
            //float speed = Mathf.Lerp(10, 0, Time.deltaTime * 50);
            onTv.material.SetFloat("_TimeLine", countDown * Time.deltaTime);
        }

        
    }
}
