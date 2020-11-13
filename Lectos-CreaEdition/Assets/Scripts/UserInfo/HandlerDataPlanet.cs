using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandlerDataPlanet : MonoBehaviour
{
    public Button[] planets;

    private GalaxiaAData _Data;

    private void Start() {
        _Data = GameObject.Find("DataUser").GetComponent<GalaxiaAData>();
        if (_Data.dataloaded) {
            Debug.Log("Data Loaded sucess ");
            for (int i = 0; i < planets.Length; i++) {
                planets[i].interactable = true ^ _Data.PlanetsV[i].Block;
                _Data.PlanetDataSaved(1, true, 0,0);
                _Data.PlanetDataSaved(2, true, 0, 0);
                Debug.Log(planets[i].interactable);
            }
        }
        else {
            _Data.LoadData();
            TryLoadData();
        }
    }

    private void TryLoadData() {
        if (_Data.dataloaded) {
            Debug.Log("Data Loaded sucess ");
            for (int i = 0; i < planets.Length; i++) {
                planets[i].interactable = _Data.PlanetsV[i].Block;
            }
        }
        else {
            _Data.LoadData();
            return;
        }
    }

    private void SaveDataPlanets(int idPlanet) {
        
    }
}
