using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorLvl : MonoBehaviour {

    public int idLvl;
    private Button planetButton;
    private GameManager _gameManager;

	void Awake () {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        planetButton = GetComponent<Button>();
        planetButton.interactable = false;
	}

	void Update ()
    {

        if (_gameManager.enableLevels[idLvl - 1])
        {
            planetButton.interactable = true;
        }
        else
        {
            planetButton.interactable = false;
        }
 
    }
}
