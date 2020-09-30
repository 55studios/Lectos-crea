using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorsTrain : MonoBehaviour {

    public bool dragable = true;
    public float speed;
    [HideInInspector]
    public Transform origin;
    [HideInInspector]
    public bool dragging = false;
    private ConectorManagerTrain conectorManager;
    private LineRenderer lineRenderer;
    private AudioSource Phonem;
    [HideInInspector]
    public int id;

    private CheckAnswer2 ca;

    void Start()
    {
        ca = GameObject.Find("checkAnswer").GetComponent<CheckAnswer2>();
        conectorManager = GameObject.Find("ConectorGenerator").GetComponent<ConectorManagerTrain>();
        Phonem = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(1, transform.position);

        if (id == 0)
        {
            origin = GameObject.Find("SpwanActivator_1").transform;

        }
        else if (id == 1)
        {
            origin = GameObject.Find("SpwanActivator_2").transform;

        }
        else if (id == 2)
        {
            origin = GameObject.Find("SpwanActivator_3").transform;
        }
        else if (id == 3)
        {
            origin = GameObject.Find("SpwanActivator_4").transform;
        }
        else if (id == 4)
        {
            origin = GameObject.Find("SpwanActivator_5").transform;
        }


    }

    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);

        if (!conectorManager.correctAnswers.GameInit)
        {
            Destroy(gameObject);
        }

        if (dragable && !dragging)
        {
            transform.position = Vector3.Lerp(transform.position, origin.position, Time.deltaTime * speed);
        }

    }

    void OnMouseDrag()
    {
        if (dragable)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnMouseDown()
    {
        dragging = true;
        ca.id = id;
        ca.ac = transform.GetComponent<ActivatorsTrain>();
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void OnMouseOver()
    {
        if (!Phonem.isPlaying)
        {
            Phonem.Play();
        }
        else
        {
            return;
        }
    }
}
