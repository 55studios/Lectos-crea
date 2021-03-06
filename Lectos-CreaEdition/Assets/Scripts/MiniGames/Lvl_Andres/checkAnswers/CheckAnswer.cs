﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnswer : MonoBehaviour {

    public int answer = -1;
    public int id = -1;

    public Receptors re;
    public Activators ac;

    private ConectorManager conectorManager;

    // Use this for initialization
    void Start () {
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManager>();
    }
	
	// Update is called once per frame
	void Update () {
        print("answer="+answer);
        print("id="+id);

        if (Input.GetMouseButtonUp(0)) {
            CheckCorrectAnswer();
            id = -1;
        }
	}

    void CheckCorrectAnswer() {
        if (id > -1 && id == answer) {
            re.compareAnswers(answer);
            Destroy(ac.gameObject);
        }
    }
}
