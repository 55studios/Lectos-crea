using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateFaces : MonoBehaviour {

	
    public GameObject faces_;

    private Button planet_;

	void Start ()
    {
        planet_ = GetComponent<Button>();
        faces_.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (planet_.IsInteractable())
        {
            faces_.SetActive(true);
        }
        else {
            faces_.SetActive(false);
        }
		
	}
}
