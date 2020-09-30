using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Com.LuisPedroFonseca.ProCamera2D;

public class goToPlanet1 : MonoBehaviour {

    public int indexScene;
    public GameObject slider;
    public GameObject rocket;
    public AudioSource rocketAudio;
    public AudioClip[] clips;
    private Animator rockerAnim;
    private ProCamera2DTransitionsFX _Fx;

    private Slider sliderProgress;

    void Start()
    {
        _Fx = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ProCamera2DTransitionsFX>();
        rockerAnim = rocket.GetComponent<Animator>();
        rocketAudio.clip = clips[0];
        rocketAudio.Play();
        _Fx.TransitionEnter();
        sliderProgress = slider.GetComponent<Slider>();
        slider.SetActive(false);
        StartCoroutine(InitButtonStart());
    }

    IEnumerator InitButtonStart()
    {
        yield return new WaitForSeconds(9);
        rocketAudio.clip = clips[1];
        rocketAudio.loop = true;
        rocketAudio.Play();
        pressForInit();
        yield return null;
    }

    public void pressForInit()
    {
        slider.SetActive(true);
        rocketAudio.clip = clips[2];
        rocketAudio.loop = false;
        rocketAudio.Play();
        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
    {
        /*while (sliderProgress.value < 1)
        {
            sliderProgress.value += 0.05f;
            yield return new WaitForSeconds(0.1f);
        }
        if (sliderProgress.value == 1)
        {
            rockerAnim.SetTrigger("LoadEnd");
            yield return new WaitForSeconds(3.45f);
            _Fx.TransitionExit();
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(indexScene);
        }*/
        AsyncOperation operation = SceneManager.LoadSceneAsync(indexScene);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            sliderProgress.value = progress;
            Debug.Log(operation.progress);
            yield return null;
            if (operation.progress == 0.9f )
            {
                sliderProgress.value = 1;
                yield return new WaitForSeconds(3.45f);
                _Fx.TransitionExit();
                yield return new WaitForSeconds(5);
                operation.allowSceneActivation = true;
            }
        }
    }
}
