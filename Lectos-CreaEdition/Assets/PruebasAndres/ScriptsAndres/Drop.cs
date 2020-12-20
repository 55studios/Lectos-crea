using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    bool correcta;
    bool incorrecta;
    GameObject activadorCorrecto;
    AudioSource errorAS;
    public Sprite[] frames;
    int frame = 0;
    public bool hielo;
    public bool vehiculos;
    public bool temporal;
    public Transform posActivador;
    public AudioSource audioS;
    public AudioClip miSonido;
    public int tipoDeVehiculo;

    private void Start()
    {
        if (vehiculos)
        {
            switch (tipoDeVehiculo)
            {
                case 0: //tren                   
                    float valor = 6f;
                    float otroValor = -9.5f;
                    BoxCollider2D bc = GetComponent<BoxCollider2D>();
                    bc.size = new Vector2(valor, valor);
                    bc.offset = new Vector2 (otroValor, 0);
                    GameObject marco = transform.Find("Marco").gameObject;
                    marco.transform.position = new Vector3(transform.position.x - 2.8f, transform.position.y + 0.2f, transform.position.z);
                    break;
                case 1: //naves
                    float valor1 = 5f;
                    float otroValor1 = -7f;
                    BoxCollider2D bc1 = GetComponent<BoxCollider2D>();
                    bc1.size = new Vector2(valor1, valor1);
                    bc1.offset = new Vector2(otroValor1, 0);
                    GameObject marco1 = transform.Find("Marco").gameObject;
                    marco1.transform.position = new Vector3(transform.position.x - 2.4f, transform.position.y, transform.position.z);
                    break;
                case 2: //asteroides
                    float valor2 = 8.5f;
                    float otroValor2 = -12f;
                    BoxCollider2D bc2 = GetComponent<BoxCollider2D>();
                    bc2.size = new Vector2(valor2, valor2);
                    bc2.offset = new Vector2(otroValor2, 0);
                    GameObject marco2 = transform.Find("Marco").gameObject;
                    marco2.transform.position = new Vector3(transform.position.x - 3.5f, transform.position.y + 0.2f, transform.position.z);
                    break;
                case 3: //estrellas
                    float valor3 = 8f;
                    float otroValor3 = -4.5f;
                    BoxCollider2D bc3 = GetComponent<BoxCollider2D>();
                    bc3.size = new Vector2(valor3, valor3);
                    bc3.offset = new Vector2(otroValor3, 0);
                    GameObject marco3 = transform.Find("Marco").gameObject;
                    marco3.transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y + 0.2f, transform.position.z);
                    break;
                default:
                    print("No hay vehiculos");
                    break;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && correcta)
        {
            if (audioS != null && miSonido != null)
            {
                audioS.Stop();
                audioS.clip = miSonido;
                audioS.Play();
            }
            if (frames.Length > 1)
            {
                CambiarImagen();
                InvokeRepeating("Animar", 0, 0.2f);
            } else
            {
                CambiarImagen();
            }
            if (hielo)
            {
                transform.Find("Hielo").gameObject.SetActive(false);
            }
            if (vehiculos)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                activadorCorrecto.transform.SetParent(gameObject.transform);
                activadorCorrecto.GetComponent<Drag>().enabled = false;
                activadorCorrecto.transform.position = posActivador.position;
                GameObject.FindWithTag("AnimadorVehiculos").GetComponent<AnimarVehiculos>().Mover();
            } else
            {
                if (!temporal)
                {
                    Destroy(activadorCorrecto);
                    Destroy(gameObject, 1f);
                }               
            }
             if (temporal)
            {
                activadorCorrecto.GetComponent<Drag>().enabled = false;
                activadorCorrecto.transform.position = transform.position;
                Destroy(gameObject);
            }
        } else if (Input.GetMouseButtonUp(0) && incorrecta)
        {
            incorrecta = false;
            GameObject controlador = GameObject.FindWithTag("GameController");
            controlador.GetComponent<CreateLevel>().Error();
            //print("llamando error");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.Find("Marco").gameObject.SetActive(true);
        //print("entro");
        if (GetComponent<Respuesta>().respuesta == collision.GetComponent<Respuesta>().respuesta)
        {
            //print("Es correcta la entrada");
            correcta = true;
            incorrecta = false;
            activadorCorrecto = collision.gameObject;
            
        } else
        {
            //print("Es incorrecta la entrada: " + GetComponent<Respuesta>().respuesta + " - " + collision.GetComponent<Respuesta>().respuesta);
            incorrecta = true;
            correcta = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        correcta = false;
        incorrecta = false;
        transform.Find("Marco").gameObject.SetActive(false);
    }

    void Animar()
    {
        GetComponent<SpriteRenderer>().sprite = frames[frame];
        frame++;
        if (frame == frames.Length - 1)
        {
            frame = 0;
        }
    }

    void CambiarImagen ()
    {
        //print("se llamo");
        GameObject controlador = GameObject.FindWithTag("GameController");
        controlador.GetComponent<CreateLevel>().RespuestaCorrecta(transform.position);
    }
}
