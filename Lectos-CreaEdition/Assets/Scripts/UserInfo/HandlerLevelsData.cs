using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoonsLevel {
    MoonOne,
    MoonTwo,
    MoonTree
}

[System.Serializable]
public class FieldsOfGame {
    public GameObject LevelButton;
    public bool isActive;
    public bool[] Stars = new bool[3];
    public float TimePlay = 0.0f;
    public float RecordTime = 0;
}

public class HandlerLevelsData : MonoBehaviour
{
    //public string PlanetName = "Planeta amarillo";
    public MoonsLevel moon = MoonsLevel.MoonOne;
    public Sprite Star;
    public Sprite BlockStar;
    //public FieldsOfGame[] _LevelsData;
    public List<FieldsOfGame> _LevelsData;
    private int _FirstTime = 0;
    private string dataPlanet;
    private GameObject contend;
    private int boleanActivelevel;
    private int currentLevel;

    private void Awake() {
        Debug.Log(_FirstTime);
        switch (moon) {
            case MoonsLevel.MoonOne:
                contend = GameObject.Find("Contend_1");
                break;
            case MoonsLevel.MoonTwo:
                contend = GameObject.Find("Contend_2");
                break;
            case MoonsLevel.MoonTree:
                contend = GameObject.Find("Contend_3");
                break;
        }
            //_LevelsData = new FieldsOfGame[contend.transform.childCount];
            if (PlayerPrefs.GetInt(moon.ToString() + "FirstTime", _FirstTime) == 0) {
            for (int i = 0; i < _LevelsData.Count; i++) {
                _LevelsData[i].LevelButton = contend.transform.GetChild(i).gameObject;
                if (i == 0) {
                    _LevelsData[i].isActive = true;
                    PlayerPrefs.SetInt(moon.ToString() + "activateLevel" + i.ToString(), 1);
                    _LevelsData[i].LevelButton.transform.GetComponent<Button>().interactable = true;
                }
                else {
                    _LevelsData[i].isActive = false;
                    PlayerPrefs.SetInt(moon.ToString() + "activateLevel" + i.ToString(), 0);
                    _LevelsData[i].LevelButton.transform.GetComponent<Button>().interactable = false;
                }
                _LevelsData[i].TimePlay = 0.0f;
                PlayerPrefs.SetFloat(moon.ToString() + "timePlay" + i.ToString(), _LevelsData[i].TimePlay);
                _LevelsData[i].RecordTime = 0.0f;
                PlayerPrefs.SetFloat(moon.ToString() + "record" + i.ToString(), _LevelsData[i].RecordTime);
                    for (int s = 0; s < _LevelsData[i].Stars.Length; s++) {
                        _LevelsData[i].Stars[s] = false;
                        _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(s).GetComponent<Image>().sprite = BlockStar;
                    PlayerPrefs.SetInt(moon.ToString() + "totalStar" + i.ToString(), 0);
                    }
                }
                _FirstTime = 1;
                 PlayerPrefs.SetInt(moon.ToString() + "FirstTime", _FirstTime);
            }
            else {
                ReadLevelData();
            }
        }

    /*
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
        */

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
            //StartCoroutine(WriteJson());
        }

    /*
        IEnumerator WriteJson() {
            dataPlanet = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(PlanetName, dataPlanet);
            yield return null;
        }
        */

    public void WriteLevelData(MoonsLevel moon, int level, bool activateLevel, int totalStars, float timePlay, float record) {
        boleanActivelevel = activateLevel ? 1 : 0;
        PlayerPrefs.SetInt(moon.ToString() + "level", level);
        PlayerPrefs.SetInt(moon.ToString() + "activateLevel" + level.ToString(), boleanActivelevel);
        _LevelsData[level].isActive = activateLevel;
        PlayerPrefs.SetInt(moon.ToString() + "totalStar" + level.ToString(), totalStars);
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
        _LevelsData[level].isActive = activateLevel;
        PlayerPrefs.SetFloat(moon.ToString() + "timePlay" + level.ToString(), timePlay);
        _LevelsData[level].TimePlay = timePlay;
        PlayerPrefs.SetFloat(moon.ToString() + "record" + level.ToString(), record);
        _LevelsData[level].RecordTime = record;
    }

    public void ReadLevelData() {
        for (int i = 0; i < _LevelsData.Count; i++) {
            _LevelsData[i].LevelButton = contend.transform.GetChild(i).gameObject;

            switch (PlayerPrefs.GetInt(moon.ToString() + "activateLevel" + i.ToString(), boleanActivelevel)) {
                case 0:
                    _LevelsData[i].isActive = false;
                    _LevelsData[i].LevelButton.transform.GetComponent<Button>().interactable = false;
                    break;
                case 1:
                    _LevelsData[i].isActive = true;
                    _LevelsData[i].LevelButton.transform.GetComponent<Button>().interactable = true;
                    break;
            }

            _LevelsData[i].TimePlay = PlayerPrefs.GetFloat(moon.ToString() + "timePlay" + i.ToString());
            _LevelsData[i].RecordTime = PlayerPrefs.GetFloat(moon.ToString() + "record" + i.ToString());

            switch (PlayerPrefs.GetInt(moon.ToString() + "totalStar" + i.ToString())) {
                case 0:
                    _LevelsData[i].Stars[0] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = BlockStar;
                    _LevelsData[i].Stars[1] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = BlockStar;
                    _LevelsData[i].Stars[2] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                    break;
                case 1:
                    _LevelsData[i].Stars[0] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                    _LevelsData[i].Stars[1] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = BlockStar;
                    _LevelsData[i].Stars[2] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                    break;
                case 2:
                    _LevelsData[i].Stars[0] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                    _LevelsData[i].Stars[1] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Star;
                    _LevelsData[i].Stars[2] = false;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = BlockStar;
                    break;
                case 3:
                    _LevelsData[i].Stars[0] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = Star;
                    _LevelsData[i].Stars[1] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = Star;
                    _LevelsData[i].Stars[2] = true;
                    _LevelsData[i].LevelButton.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = Star;
                    break;
            }
        }
    }
}


