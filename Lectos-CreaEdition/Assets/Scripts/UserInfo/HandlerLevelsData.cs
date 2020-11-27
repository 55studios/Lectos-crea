using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlerLevelsData : MonoBehaviour
{
    public string PlanetName = "Planeta amarillo";
    private int _FirstTime = 0;

    public Sprite Star;
    public Sprite BlockStar;

    public FieldsOfGame[] _LevelsData;

    private string dataPlanet;

    private void Awake() {
        _FirstTime = PlayerPrefs.GetInt(PlanetName + "startGame", _FirstTime);
        if (_FirstTime == 0) {
            for (int i = 0; i < _LevelsData.Length; i++) {
                _LevelsData[i].Stars = new bool[3];
                _LevelsData[i].RecordTime = 0.0f;
                _LevelsData[i].isActive = false;
                _LevelsData[i].LevelButton.transform.GetComponent<Button>().interactable = false;
                for (int s = 0; s < _LevelsData[i].Stars.Length; s++) {
                    _LevelsData[i].Stars[s] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(s).GetComponent<Image>().sprite = BlockStar;
                }
            }
            _LevelsData[0].isActive = true;
            _LevelsData[0].LevelButton.GetComponent<Button>().interactable = true;
            for (int i = 0; i < _LevelsData[0].Stars.Length; i++) {
                _LevelsData[0].Stars[i] = false;
            }
            _FirstTime = 1;
            PlayerPrefs.SetInt(PlanetName + "startGame", _FirstTime);
            StartCoroutine(WriteJson());
            print(PlayerPrefs.GetString(PlanetName));
        }
        else {
            ReadData();
        }
    }

    void ReadData() {
        string data = PlayerPrefs.GetString(PlanetName);
        if (data == null) {
            return;
        }
        print("Load data: " + data);
        JsonUtility.FromJsonOverwrite(data, this);
        for (int i = 0; i < _LevelsData.Length; i++) {
            _LevelsData[i].LevelButton.GetComponent<Button>().interactable = _LevelsData[i].isActive;
            for (int s = 0; s < _LevelsData[i].Stars.Length; s++) {
                if (_LevelsData[i].Stars[s] == true) {
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(s).GetComponent<Image>().sprite = Star;
                }
                else {
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(s).GetComponent<Image>().sprite = BlockStar;
                }
            }
        }
    }

    public void WriteDataAndUpdate(int level, bool activateLevel, int totalStars, float record) {
        _LevelsData[level].isActive = activateLevel;
        _LevelsData[level].LevelButton.GetComponent<Button>().interactable = _LevelsData[level].isActive;
        switch (totalStars) {
            case 0:
                _LevelsData[level].Stars[0] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = BlockStar;
                _LevelsData[level].Stars[1] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = BlockStar;
                _LevelsData[level].Stars[2] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                break;
            case 1:
                _LevelsData[level].Stars[0] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                _LevelsData[level].Stars[1] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = BlockStar;
                _LevelsData[level].Stars[2] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                break;
            case 2:
                _LevelsData[level].Stars[0] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                _LevelsData[level].Stars[1] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Star;
                _LevelsData[level].Stars[2] = false;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                break;
            case 3:
                _LevelsData[level].Stars[0] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                _LevelsData[level].Stars[1] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Star;
                _LevelsData[level].Stars[2] = true;
                _LevelsData[level].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = Star;
                break;
        }
        _LevelsData[level].RecordTime = record;
        StartCoroutine(WriteJson());
    }

    IEnumerator WriteJson() {
        dataPlanet = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(PlanetName, dataPlanet);
        yield return null;
    }
}

[System.Serializable]
public class FieldsOfGame {
    public GameObject LevelButton;
    public bool isActive;
    public bool[] Stars = new bool[3];
    public float RecordTime = 0;
}
