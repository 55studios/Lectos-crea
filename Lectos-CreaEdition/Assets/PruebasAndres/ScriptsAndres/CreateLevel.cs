using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLevel : MonoBehaviour
{
    public MinigameData MGD;
    public GameObject activadorPrefab;
    public GameObject receptorPrefab;
    public GameObject receptorCongeladoPrefab;
    public GameObject receptorTextoPrefab;
    public GameObject receptorMemoriaPrefab;
    public GameObject receptorSonidosPrefab;
    public GameObject InterfazFinMinijuego;
    public GameObject receptorTrenPrefab;

    Organizador Or;
    AudioSource As;
    GameObject[] receptoresCreados;
    int posicionListaReceptores;
    int puntaje;
    int maxPuntaje;
    string nombreMinijuego;
    bool creado;
    float timeStart;
    float timeEnd;
    bool temporalFake;

    public void Cargar (string s)
    {
        InterfazFinMinijuego.SetActive(false);
        puntaje = 0;
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        nombreMinijuego = s;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!creado)
        {
            creado = true;
            maxPuntaje = MGD.puntosLogrables;
            timeStart = Time.deltaTime;
            Or = GameObject.FindGameObjectWithTag("Organizador").GetComponent<Organizador>();
            As = GetComponent<AudioSource>();
            switch (MGD.Tipo)
            {
                case 0: //drag&drop 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activ = Or.activadores;
                    Transform[] recep = Or.receptores;
                    DragAndDrop Dyd = (DragAndDrop)MGD;
                    CreateSprites(activ, Dyd.arrastrables, activadorPrefab, Dyd.variante, Dyd.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recep, Dyd.receptores, receptorPrefab, Dyd.variante, Dyd.sonidosCorrecto, Or.gameObject);
                    break;
                case 1: //escribir palabra
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepText = Or.receptores;
                    Escribir Es = (Escribir)MGD;
                    CreateSpritesText(recepText, Es.respuestas, receptorTextoPrefab, Es.sonidosRespuestas, Or.gameObject);
                    break;
                case 2: //memoria
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepMemo = Or.receptores;
                    Memoria Me = (Memoria)MGD;
                    CreateSpritesMemoria(recepMemo, Me.parejasElemento1, Me.parejasElemento2, receptorMemoriaPrefab, Me.flip, Or.gameObject);
                    break;
                case 3: //sonidos
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepSonido = Or.receptores;
                    Sonidos So = (Sonidos)MGD;
                    CreateSpritesSonidos(recepSonido, So.clickeables, So.sonidosParlante, receptorSonidosPrefab, So.sonidosCorrecto, Or.gameObject);
                    break;
                case 4: //congelados 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activCon = Or.activadores;
                    Transform[] recepCon = Or.receptores;
                    Congelados DydCon = (Congelados)MGD;
                    CreateSprites(activCon, DydCon.arrastrables, activadorPrefab, DydCon.variante, DydCon.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recepCon, DydCon.receptores, receptorCongeladoPrefab, DydCon.variante, DydCon.sonidosCorrecto, Or.gameObject);
                    break;
                case 5: //tren 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activTren = Or.activadores;
                    Transform[] recepTren = Or.receptores;
                    Vehiculos DydTren = (Vehiculos)MGD;
                    CreateSprites(activTren, DydTren.arrastrables, activadorPrefab, DydTren.variante, DydTren.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recepTren, DydTren.receptores, receptorTrenPrefab, DydTren.variante, DydTren.sonidosCorrecto, Or.gameObject);
                    break;
                case 6: //canchas 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activCan = Or.activadores;
                    Transform[] recepCan = Or.receptores;
                    Canchas DydCan = (Canchas)MGD;
                    CreateSpritesCanchas(activCan, DydCan.arrastrables, activadorPrefab, DydCan.animacionFinal, DydCan.sonidosArrastrar, Or.gameObject);
                    CreateSpritesCanchas(recepCan, DydCan.receptores, receptorPrefab, DydCan.animacionFinal, DydCan.sonidosCorrecto, Or.gameObject);
                    break;
                case 7: //habitaciones 
                    As.clip = MGD.sonidoAcierto;
                    temporalFake = true;
                    break;
                case 8: //rompecabezas 
                    As.clip = MGD.sonidoAcierto;
                    temporalFake = true;
                    break;
                default:
                    print("No tipo de minijuego");
                    break;
            }
        }
    }

    void CreateSprites (Transform[] posiciones, SpriteAsset[] imagenes, GameObject prefab, int variante, AudioClip[] sonidos, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        if (posiciones.Length > 1)
        {
            for (int i = 0; i < posiciones.Length; i++)
            {
                Sprite[] temporales = imagenes[i].frames;
                GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
                elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
                elemento.GetComponent<Respuesta>().respuesta = i;
                if (elemento.GetComponent<Drop>() != null)
                {
                    elemento.GetComponent<Drop>().frames = temporales;
                    elemento.GetComponent<Drop>().miSonido = sonidos[i];
                    elemento.GetComponent<Drop>().audioS = reproductor.GetComponent<AudioSource>();
                    if (variante == 1)
                    {
                        elemento.GetComponent<Drop>().hielo = true;
                    } else if (variante == 2)
                    {
                        elemento.transform.SetParent(posiciones[i]);
                        elemento.GetComponent<Drop>().vehiculos = true;
                        elemento.GetComponent<Drop>().posActivador = posiciones[i].transform.Find("1").transform;
                    }
                }
                if (elemento.GetComponent<Drag>() != null)
                {
                    elemento.GetComponent<Drag>().miSonido = sonidos[i];
                    elemento.GetComponent<Drag>().audioS = reproductor.GetComponent<AudioSource>();
                }
            }
        } else
        {
            receptoresCreados = new GameObject[imagenes.Length];
            for (int i = 0; i < imagenes.Length; i++)
            {
                Sprite[] temporales = imagenes[i].frames;
                GameObject elemento = Instantiate(prefab, posiciones[0].position, Quaternion.identity);
                elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
                elemento.GetComponent<Respuesta>().respuesta = i;
                receptoresCreados[i] = elemento;
                if (i > 0)
                {
                    elemento.SetActive(false);
                }
                if (elemento.GetComponent<Drop>() != null)
                {
                    elemento.GetComponent<Drop>().frames = temporales;
                    elemento.GetComponent<Drop>().miSonido = sonidos[i];
                    elemento.GetComponent<Drop>().audioS = reproductor.GetComponent<AudioSource>();
                    if (variante == 1)
                    {
                        elemento.GetComponent<Drop>().hielo = true;
                    }
                    else if (variante == 2)
                    {
                        elemento.transform.SetParent(posiciones[i]);
                        elemento.GetComponent<Drop>().vehiculos = true;
                        elemento.GetComponent<Drop>().posActivador = posiciones[i].transform.Find("1").transform;
                    }
                }
                if (elemento.GetComponent<Drag>() != null)
                {
                    elemento.GetComponent<Drag>().miSonido = sonidos[i];
                    elemento.GetComponent<Drag>().audioS = reproductor.GetComponent<AudioSource>();
                }
            }
            posicionListaReceptores = 0;
        }
    }

    void CreateSpritesText (Transform[] posiciones, SpriteAsset[] imagenes, GameObject prefab, AudioClip[] sonidos, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        receptoresCreados = new GameObject[imagenes.Length];
        for (int i = 0; i < imagenes.Length; i++)
        {
            Sprite[] temporales = imagenes[i].frames;
            GameObject elemento = Instantiate(prefab, posiciones[0].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
            elemento.GetComponent<RespuestaTexto>().respuesta = imagenes[i].name;
            if (elemento.GetComponent<CheckText>() != null)
            {
                elemento.GetComponent<CheckText>().miSonido = sonidos[i];
                elemento.GetComponent<CheckText>().audioS = reproductor.GetComponent<AudioSource>();
            }           
            receptoresCreados[i] = elemento;
            if (i > 0)
            {
                elemento.SetActive(false);
            }
        }
        posicionListaReceptores = 0;
    }

    void CreateSpritesMemoria(Transform[] posiciones, SpriteAsset[] imagenes1, SpriteAsset[] imagenes2, GameObject prefab, AudioClip flip, GameObject reproductor)
    {
        int n = 0;
        System.Array.Sort(posiciones, RandomSort);
        for (int i = 0; i < imagenes1.Length; i++)
        {
            if (n != 0)
            {
                n++;
            }
            Sprite[] temporales = imagenes1[i].frames;
            GameObject elemento = Instantiate(prefab, posiciones[n].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
            elemento.GetComponent<Respuesta>().respuesta = i;
            elemento.GetComponent<Memo>().checker = Or.gameObject;
            if (flip != null)
            {
                elemento.GetComponent<Memo>().miSonido = flip;
                elemento.GetComponent<Memo>().audioS = reproductor.GetComponent<AudioSource>();
            }            
            n++;
            Sprite[] temporales2 = imagenes2[i].frames;
            GameObject elemento2 = Instantiate(prefab, posiciones[n].position, Quaternion.identity);
            elemento2.GetComponent<SpriteRenderer>().sprite = temporales2[0];
            elemento2.GetComponent<Respuesta>().respuesta = i;
            elemento2.GetComponent<Memo>().checker = Or.gameObject;
            if (flip != null)
            {
                elemento2.GetComponent<Memo>().miSonido = flip;
                elemento.GetComponent<Memo>().audioS = reproductor.GetComponent<AudioSource>();
            }
        }
    }

    void CreateSpritesSonidos(Transform[] posiciones, SpriteAsset[] imagenes, AudioClip[] audios, GameObject prefab, AudioClip[] sonidosCorrecto, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        GameObject play = GameObject.FindGameObjectWithTag("Reproductor");
        print(play);
        play.GetComponent<PlaySonidos>().sonidos = new AudioClip[audios.Length];
        play.GetComponent<PlaySonidos>().elementosSonido = new Sonido[imagenes.Length];
        for (int i = 0; i < imagenes.Length; i++)
        {
            Sprite[] temporales = imagenes[i].frames;
            GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
            elemento.GetComponent<Respuesta>().respuesta = i;
            if (elemento.GetComponent<Sonido>() != null)
            {
                elemento.GetComponent<Sonido>().frames = temporales;
                play.GetComponent<PlaySonidos>().elementosSonido[i] = elemento.GetComponent<Sonido>();
                if (sonidosCorrecto != null)
                {
                    elemento.GetComponent<Sonido>().miSonido = sonidosCorrecto[i];
                    elemento.GetComponent<Sonido>().audioS = reproductor.GetComponent<AudioSource>();
                }                
            }            
            play.GetComponent<PlaySonidos>().sonidos[i] = audios[i];
        }
    }

    void CreateSpritesCanchas(Transform[] posiciones, SpriteAsset[] imagenes, GameObject prefab, SpriteAsset[] animaciones, AudioClip[] sonidos, GameObject reproductor)
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            Sprite[] temporales = imagenes[i].frames;
            Sprite[] temporales2 = animaciones[i].frames;
            GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
            elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
            elemento.GetComponent<Respuesta>().respuesta = i;
            if (elemento.GetComponent<Drop>() != null)
            {
                elemento.GetComponent<Drop>().frames = temporales2;
                elemento.GetComponent<Drop>().miSonido = sonidos[i];
                elemento.GetComponent<Drop>().audioS = reproductor.GetComponent<AudioSource>();
            }
            if (elemento.GetComponent<Drag>() != null)
            {
                elemento.GetComponent<Drag>().miSonido = sonidos[i];
                elemento.GetComponent<Drag>().audioS = reproductor.GetComponent<AudioSource>();
            }
        }
    }

    int RandomSort(Transform a, Transform b)
    {
        return Random.Range(-1, 2);
    }

    public void RespuestaCorrecta(Vector3 posiParticulas)
    {
        print("correcto!!!!!");
        puntaje++;
        As.Play();
        if (MGD.particulasAcierto != null)
        {
            GameObject parti = Instantiate(MGD.particulasAcierto, posiParticulas, Quaternion.identity);
        }
        if (receptoresCreados != null && posicionListaReceptores < receptoresCreados.Length - 1 && !temporalFake)
        {
            Invoke("CambiarReceptor", 1f);
        }
        if (puntaje == maxPuntaje)
        {
            Invoke("TerminarMinijuego", 1f);
        }
    }

    void TerminarMinijuego ()
    {
        timeEnd = Time.deltaTime;
        print(timeStart.ToString("F2"));
        print(timeEnd.ToString("F2"));
        puntaje = 0;
        print("Terminado el juego" + nombreMinijuego);
        SceneManager.UnloadSceneAsync(nombreMinijuego);
        MGD = null;
        Or = null;
        maxPuntaje = 0;
        creado = false;
        InterfazFinMinijuego.SetActive(true);
    }

    void CambiarReceptor ()
    {
        posicionListaReceptores++;
        receptoresCreados[posicionListaReceptores].SetActive(true);
    }
    
    public void SetNextLevelButton (ListaMinigames lm, int ind)
    {
        ButtonToController siguienteNivel = InterfazFinMinijuego.transform.Find("Siguiente").GetComponent<ButtonToController>();
        siguienteNivel.Lista = lm;
        siguienteNivel.index = ind + 1;
        if (siguienteNivel.index > lm.lista.Length - 1)
        {
            siguienteNivel.gameObject.SetActive(false);
            InterfazFinMinijuego.transform.Find("LunaTerminada").gameObject.SetActive(true);
        }
        siguienteNivel.controlador = gameObject.GetComponent<CreateLevel>();

        ButtonToController repetirJuego = InterfazFinMinijuego.transform.Find("Replay").GetComponent<ButtonToController>();
        repetirJuego.Lista = lm;
        repetirJuego.index = ind;
        repetirJuego.controlador = gameObject.GetComponent<CreateLevel>();
    }

    public void CerrarMinijuego ()
    {
        TerminarMinijuego();
    }
}
