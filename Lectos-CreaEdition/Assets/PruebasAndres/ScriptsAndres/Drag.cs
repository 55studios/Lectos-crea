using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    bool moviendo;
    float posX;
    float posY;
    Vector3 originalPos;
    private LineRenderer lineRenderer;
    public AudioSource audioS;
    public AudioClip miSonido;

    public float speed;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        originalPos = this.transform.localPosition;
        lineRenderer.SetPosition(1, transform.position);
    }

    void Update()
    {
        lineRenderer.SetPosition(0, originalPos);
        if (moviendo)
        {
            Vector3 newPos;
            newPos = Input.mousePosition;
            newPos = Camera.main.ScreenToWorldPoint(newPos);
            this.gameObject.transform.localPosition = new Vector3(newPos.x - posX, newPos.y - posY, 0);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * speed);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            posX = mousePos.x - this.transform.localPosition.x;
            posY = mousePos.y - this.transform.localPosition.y;
            if (audioS != null && miSonido != null)
            {
                audioS.Stop();
                audioS.clip = miSonido;
                audioS.Play();
            }
            moviendo = true;
        }
    }

    private void OnMouseUp()
    {
        moviendo = false;
    }
}
