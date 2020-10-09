using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WriteName : MonoBehaviour {

    public Text t;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetString("Name", "");
    }
	
	// Update is called once per frame
	void Update () {
        print(PlayerPrefs.GetString("Name"));
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // al apachurrar delete borra 
            {
                if (t.text.Length != 0)
                {
                    t.text = t.text.Substring(0, t.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // al apachurrar enter guarda el nombre con la misma funcion del boton
            {
                saveName();
            }
            else
            {
                   t.text += c; //le añade la letra apachurrada al texto
            }
        }
    }

    public void saveName() {
        PlayerPrefs.SetString("Name", t.text);
        SceneManager.LoadScene("Felicitaciones");
    }
}
