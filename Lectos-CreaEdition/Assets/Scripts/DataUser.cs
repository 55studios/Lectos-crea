using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataUser : MonoBehaviour
{
    private bool Tutorial = false;

    void Start(){

        if (PlayerPrefs.GetInt("FistGame") == 0) {
            PlayerPrefs.SetInt("FistGame", 1);
        }
    }
}
