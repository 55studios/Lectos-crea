using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {


    public string nameSceneToLoad;

    private void Start()
    {
        if (nameSceneToLoad == null)
        {
            nameSceneToLoad = "MainMenu";
        }
    }

    public void LoadSceneWithClick ()
    {
        Invoke("WaitToInvoke", 0.8f);
        
	}

    void WaitToInvoke()
    {
        SceneManager.LoadScene(nameSceneToLoad);
    }
}
