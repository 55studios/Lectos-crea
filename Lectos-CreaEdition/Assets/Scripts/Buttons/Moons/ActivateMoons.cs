using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMoons : MonoBehaviour {

    private GameManager gameManager;

    public void ActivateNextMoon(int moon)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.subEnableLevels[moon] = true;
    }
}
