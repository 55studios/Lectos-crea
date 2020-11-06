using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesStandart : MonoBehaviour {

   public string currentScene;

   public void LoadScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}

