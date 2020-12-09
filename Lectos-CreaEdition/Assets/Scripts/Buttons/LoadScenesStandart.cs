using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesStandart : MonoBehaviour {

    public string currentScene;
    public GameObject transition;
    public GameObject loading;
    public float delay = 0.25f;

    private void Start() {
        loading.SetActive(true);
        StartCoroutine(DelayTime());
    }

    public void LoadScene(){
        StartCoroutine(LoadingScenes());
    }

    public void InJustTransition() {
        transition.GetComponent<Animator>().SetTrigger("In");
        //StartCoroutine(JustTarnsitionIn());
    }

    public void OutJustTransition() {
        transition.GetComponent<Animator>().SetTrigger("Out");
        //StartCoroutine(JustTarnsitionOut());
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    IEnumerator DelayTime() {
        yield return new WaitForSeconds(delay);
        loading.SetActive(false);
    }

    IEnumerator LoadingScenes() {
        loading.SetActive(true);
        transition.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(currentScene);
    }

    IEnumerator JustTarnsitionIn() {
        yield return new WaitForSeconds(3f);
    }
    IEnumerator JustTarnsitionOut() {
        yield return new WaitForSeconds(3f);
    }
}

