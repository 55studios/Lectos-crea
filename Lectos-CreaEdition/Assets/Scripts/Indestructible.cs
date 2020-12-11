using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indestructible : MonoBehaviour
{
    public static Indestructible _GameManager;

    private void Awake() {
        if (_GameManager == null) {
            _GameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_GameManager != this) {
            Destroy(gameObject);
        }
    }
}
