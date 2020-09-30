using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImages : MonoBehaviour {

    public GameObject[] images;
    public AudioClip[] audios;
    [SerializeField]
    public int index = -1;
    Vector3 rotationEuler;
    public int value = 150;
    bool rotateImage = false;
    AudioSource aSource;

    private void Awake()
    {
        index++;
        aSource = GetComponent<AudioSource>();
        aSource.clip = audios[0];
        
    }

    void Update()
    {
        if (rotateImage) {
            rotationEuler += Vector3.forward * value * Time.deltaTime;
            images[index].transform.rotation = Quaternion.Euler(rotationEuler);
        }
    }

    public void displayImage() { //la funcion que cambia de imagen
        if (index < images.Length-1) {
            rotateImage = false;
            value *= -1;
            index++;
            images[index].SetActive(true);
            aSource.clip = audios[index];
            if (index > 0 ) {
                images[index - 1].SetActive(false);
            }
        }
    }

    public string CurrentImage() {
            return images[index].name;
    }

    public void HideAllImages() {
        value = 80;
        aSource.clip = audios[0];
        rotateImage = false;
        foreach (GameObject item in images) {
            item.SetActive(false);
            item.transform.rotation = Quaternion.Euler(0,0,0);
        }
        images[0].SetActive(true);
    }

    void otherDirection()
    {
        value *= -1;
    }

    public void AllowRotation() {
        rotationEuler = Vector3.zero;
        rotateImage = true;
        Invoke("otherDirection", 0.8f);
    }
}
