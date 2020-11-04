using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandlerDataPlanet : MonoBehaviour
{
    [HideInInspector]
    public GalaxiaAData _data;

    [Header("Planet data")]
    public int planetId;
    public bool planetIsBlocked;
    public int totalStars;
    public int Totalporcent;

    [Header("Objects")]
    public Button planetButton;

    public void SaveData() {
        _data = GameObject.Find("DataUser").GetComponent<GalaxiaAData>();

        if (_data == null) {
            Debug.Log("I couldnt find the reference");
        }
        else {
            _data.PlanetDataSaved(planetId,planetIsBlocked,totalStars,Totalporcent);
            if (_data.PlanetsV[planetId].Block) {
                planetButton.interactable = false;
            }
            else {
                planetButton.interactable = true;
            }
        }
    }

    private void Start() {
        _data = GameObject.Find("DataUser").GetComponent<GalaxiaAData>();
        LoadDataPlanet();
    }

    void LoadDataPlanet() {
        if (_data == null) {
            Debug.Log("I couldnt find the reference");
        }
        else {
            if (_data.dataloaded) {
                if (_data.PlanetsV[planetId].Block) {
                    planetButton.interactable = false;
                }
                else {
                    planetButton.interactable = true;
                }
            }
            else {
                Debug.Log("Data cant be loaded");
                
            }
        }
    }

}
