using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STpoint : MonoBehaviour {

    public AudioClip sound;
    public AudioClip correctAnswer;
    public Text word;
    public Image picture;
    public int id;

    private void Start()
    {
        picture.transform.position = transform.position;
        picture.transform.GetComponent<Image>().enabled = false;
    }
}
