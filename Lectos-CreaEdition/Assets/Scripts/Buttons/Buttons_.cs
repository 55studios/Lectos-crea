using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons_ : MonoBehaviour {
    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

   public void StepBack()
    {
        SceneManager.LoadScene(currentScene.buildIndex - 1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

