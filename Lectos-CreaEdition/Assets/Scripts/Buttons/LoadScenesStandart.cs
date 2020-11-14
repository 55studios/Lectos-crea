using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesStandart : MonoBehaviour {

   public string currentScene;
    public GameObject transition;

   public void LoadScene()
    {
        StartCoroutine(LoadingScenes());
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    IEnumerator LoadingScenes() {
        transition.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(currentScene);
    }
}

