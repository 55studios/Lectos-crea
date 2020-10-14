using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool[] enableTutorial;
    public bool[] enableLevels;
    public bool[] subEnableLevels;
    public bool[] MiniGamesSubLevel_1;
    public bool trofeo;
    

    public static GameManager _GameManager;

    private DialogManager dialogManager;

    private void Awake()
    {
        if (_GameManager == null)
        {
            _GameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_GameManager!= this)
        {
            Destroy(gameObject);
        }
    }

}
