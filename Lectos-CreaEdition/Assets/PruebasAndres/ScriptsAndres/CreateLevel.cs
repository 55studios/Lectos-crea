using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public GameObject receptorAsteroidePrefab;
    public GameObject dictadoPrefab;
    public GameObject[] _Slider;
    [HideInInspector]
    public int tempLvl = 0;

    Organizador Or;
    [SerializeField]
    AudioSource As;
    GameObject[] receptoresCreados;
    int posicionListaReceptores;
    int puntaje;
    int maxPuntaje;
    string nombreMinijuego;
    bool creado;
    bool temporalFake;
    bool terminadoPorPuntaje;
    bool SwitchButtonEndGame = false;
    [SerializeField]
    AudioSource ganar;
    [SerializeField]
    AudioSource perder;
    [SerializeField]
    AudioSource error;
    ButtonToController siguienteNivel;
    int tipoDeVehiculo;
    int moonSlider = 0;
    int TempLenghtLvls = 0;

    [Space(8)]
    [Header("Events")]
    public UnityEvent OnLoadGame;
    public UnityEvent OnDisableGame;

    public void Cargar (string s)
    {
        //InterfazFinMinijuego.SetActive(false);
        InterfazFinMinijuego.GetComponent<ManagerAnimations>().OnAnimationOut();
        puntaje = 0;
        terminadoPorPuntaje = false;
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
        //SceneManager.sceneLoaded += OnSceneLoaded;
        nombreMinijuego = s;
    }

    public void CargarYPoblar(string s)
    {
        //InterfazFinMinijuego.SetActive(false);
        InterfazFinMinijuego.GetComponent<ManagerAnimations>().OnAnimationOut();
        puntaje = 0;
        terminadoPorPuntaje = false;
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        nombreMinijuego = s;
    }

    public void PoblarMinijuego ()
    {        
            if (!creado)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(nombreMinijuego));
                creado = true;
                OnLoadGame.Invoke();
                maxPuntaje = MGD.puntosLogrables;
                Or = GameObject.FindGameObjectWithTag("Organizador").GetComponent<Organizador>();
                switch (MGD.Tipo)
                {
                    case 0: //drag&drop 
                        As.clip = MGD.sonidoAcierto;
                        Transform[] activ = Or.activadores;
                        Transform[] recep = Or.receptores;
                        DragAndDrop Dyd = (DragAndDrop)MGD;
                        CreateSprites(activ, Dyd.arrastrables, activadorPrefab, Dyd.variante, Dyd.sonidosArrastrar, Or.gameObject);
                        CreateSprites(recep, Dyd.receptores, receptorPrefab, Dyd.variante, Dyd.sonidosCorrecto, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 1: //escribir palabra
                        As.clip = MGD.sonidoAcierto;
                        Transform[] recepText = Or.receptores;
                        Escribir Es = (Escribir)MGD;
                        CreateSpritesText(recepText, Es.respuestas, receptorTextoPrefab, Es.sonidosRespuestas, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 2: //memoria
                        As.clip = MGD.sonidoAcierto;
                        Transform[] recepMemo = Or.receptores;
                        Memoria Me = (Memoria)MGD;
                        CreateSpritesMemoria(recepMemo, Me.parejasElemento1, Me.parejasElemento2, receptorMemoriaPrefab, Me.flip, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 3: //sonidos
                        As.clip = MGD.sonidoAcierto;
                        Transform[] recepSonido = Or.receptores;
                        Sonidos So = (Sonidos)MGD;
                        CreateSpritesSonidos(recepSonido, So.clickeables, So.animacionCorrecto, So.sonidosParlante, receptorSonidosPrefab, So.sonidosCorrecto, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 4: //congelados 
                        As.clip = MGD.sonidoAcierto;
                        Transform[] activCon = Or.activadores;
                        Transform[] recepCon = Or.receptores;
                        Congelados DydCon = (Congelados)MGD;
                        CreateSprites(activCon, DydCon.arrastrables, activadorPrefab, DydCon.variante, DydCon.sonidosArrastrar, Or.gameObject);
                        CreateSprites(recepCon, DydCon.receptores, receptorCongeladoPrefab, DydCon.variante, DydCon.sonidosCorrecto, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 5: //tren 
                        As.clip = MGD.sonidoAcierto;
                        Transform[] activTren = Or.activadores;
                        Transform[] recepTren = Or.receptores;
                        Vehiculos DydTren = (Vehiculos)MGD;
                        tipoDeVehiculo = (int)DydTren.variacion;
                        CreateSprites(activTren, DydTren.arrastrables, activadorPrefab, DydTren.variante, DydTren.sonidosArrastrar, Or.gameObject);
                        CreateSprites(recepTren, DydTren.receptores, receptorTrenPrefab, DydTren.variante, DydTren.sonidosCorrecto, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 6: //canchas 
                        As.clip = MGD.sonidoAcierto;
                        Transform[] activCan = Or.activadores;
                        Transform[] recepCan = Or.receptores;
                        Canchas DydCan = (Canchas)MGD;
                        CreateSpritesCanchas(activCan, DydCan.arrastrables, activadorPrefab, DydCan.animacionFinal, DydCan.sonidosArrastrar, Or.gameObject);
                        CreateSpritesCanchas(recepCan, DydCan.receptores, receptorPrefab, DydCan.animacionFinal, DydCan.sonidosCorrecto, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 7: //habitaciones 
                        As.clip = MGD.sonidoAcierto;
                        temporalFake = true;
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 8: //rompecabezas 
                        As.clip = MGD.sonidoAcierto;
                        temporalFake = true;
                        Transform[] activPuz = Or.activadores;
                        Transform[] recepPuz = Or.receptores;
                        Puzzle DydPuz = (Puzzle)MGD;
                        CreateSpritesRompecabezas(activPuz, recepPuz[0], DydPuz.Completo, DydPuz.piezas, DydPuz.sonidoPalabra, DydPuz.sonidoElemento, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    case 9: //dictado 
                        As.clip = MGD.sonidoAcierto;
                        Transform[] activDic = Or.activadores;
                        Transform[] recepDic = Or.receptores;
                        Dictado Dic = (Dictado)MGD;
                        CreateSpritesDictado(activDic[0], recepDic[0], Dic.imagenes, dictadoPrefab, Dic.prefabPalabras, Dic.sonidoRespuestas, Or.gameObject);
                        GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                        break;
                    default:
                        print("No tipo de minijuego");
                        break;
                }
            }       
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!creado)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(nombreMinijuego));
            creado = true;
            OnLoadGame.Invoke();
            maxPuntaje = MGD.puntosLogrables;
            Or = GameObject.FindGameObjectWithTag("Organizador").GetComponent<Organizador>();
            switch (MGD.Tipo)
            {
                case 0: //drag&drop 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activ = Or.activadores;
                    Transform[] recep = Or.receptores;
                    DragAndDrop Dyd = (DragAndDrop)MGD;
                    CreateSprites(activ, Dyd.arrastrables, activadorPrefab, Dyd.variante, Dyd.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recep, Dyd.receptores, receptorPrefab, Dyd.variante, Dyd.sonidosCorrecto, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 1: //escribir palabra
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepText = Or.receptores;
                    Escribir Es = (Escribir)MGD;
                    CreateSpritesText(recepText, Es.respuestas, receptorTextoPrefab, Es.sonidosRespuestas, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 2: //memoria
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepMemo = Or.receptores;
                    Memoria Me = (Memoria)MGD;
                    CreateSpritesMemoria(recepMemo, Me.parejasElemento1, Me.parejasElemento2, receptorMemoriaPrefab, Me.flip, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 3: //sonidos
                    As.clip = MGD.sonidoAcierto;
                    Transform[] recepSonido = Or.receptores;
                    Sonidos So = (Sonidos)MGD;
                    CreateSpritesSonidos(recepSonido, So.clickeables, So.animacionCorrecto, So.sonidosParlante, receptorSonidosPrefab, So.sonidosCorrecto, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 4: //congelados 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activCon = Or.activadores;
                    Transform[] recepCon = Or.receptores;
                    Congelados DydCon = (Congelados)MGD;
                    CreateSprites(activCon, DydCon.arrastrables, activadorPrefab, DydCon.variante, DydCon.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recepCon, DydCon.receptores, receptorCongeladoPrefab, DydCon.variante, DydCon.sonidosCorrecto, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 5: //tren 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activTren = Or.activadores;
                    Transform[] recepTren = Or.receptores;
                    Vehiculos DydTren = (Vehiculos)MGD;
                    tipoDeVehiculo = (int)DydTren.variacion;
                    CreateSprites(activTren, DydTren.arrastrables, activadorPrefab, DydTren.variante, DydTren.sonidosArrastrar, Or.gameObject);
                    CreateSprites(recepTren, DydTren.receptores, receptorTrenPrefab, DydTren.variante, DydTren.sonidosCorrecto, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 6: //canchas 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activCan = Or.activadores;
                    Transform[] recepCan = Or.receptores;
                    Canchas DydCan = (Canchas)MGD;
                    CreateSpritesCanchas(activCan, DydCan.arrastrables, activadorPrefab, DydCan.animacionFinal, DydCan.sonidosArrastrar, Or.gameObject);
                    CreateSpritesCanchas(recepCan, DydCan.receptores, receptorPrefab, DydCan.animacionFinal, DydCan.sonidosCorrecto, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 7: //habitaciones 
                    As.clip = MGD.sonidoAcierto;
                    temporalFake = true;
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 8: //rompecabezas 
                    As.clip = MGD.sonidoAcierto;
                    temporalFake = true;
                    Transform[] activPuz = Or.activadores;
                    Transform[] recepPuz = Or.receptores;
                    Puzzle DydPuz = (Puzzle)MGD;
                    CreateSpritesRompecabezas(activPuz, recepPuz[0], DydPuz.Completo, DydPuz.piezas, DydPuz.sonidoPalabra, DydPuz.sonidoElemento, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
                    break;
                case 9: //dictado 
                    As.clip = MGD.sonidoAcierto;
                    Transform[] activDic = Or.activadores;
                    Transform[] recepDic = Or.receptores;
                    Dictado Dic = (Dictado)MGD;
                    CreateSpritesDictado(activDic[0], recepDic[0], Dic.imagenes, dictadoPrefab, Dic.prefabPalabras, Dic.sonidoRespuestas, Or.gameObject);
                    GetComponent<Tiempo>().Iniciar(MGD.tiemposAVencer);
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
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        GameObject[] elementosCreados = new GameObject[imagenes.Length];
        bool sonDrop = false;
        if (posiciones.Length > 1)
        {
            for (int i = 0; i < imagenes.Length; i++)
            {
                Sprite[] temporales = imagenes[i].frames;
                GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
                if (variante < 1)
                {
                    elemento.transform.localScale = posiciones[i].localScale;
                }
                //elemento.transform.localScale = posiciones[i].localScale;
                elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
                elemento.GetComponent<Respuesta>().respuesta = i;
                if (elemento.GetComponent<Drop>() != null)
                {
                    sonDrop = true;
                    print(sonDrop);
                    elementosCreados[i] = elemento;
                    elemento.GetComponent<Drop>().frames = temporales;
                    elemento.GetComponent<Drop>().miSonido = sonidos[i];
                    elemento.GetComponent<Drop>().audioS = reproductor.GetComponent<AudioSource>();
                    if (variante == 1)
                    {
                        elemento.GetComponent<Drop>().hielo = true;
                    } else if (variante == 2)
                    {
                        elemento.GetComponent<Drop>().vehiculos = true;
                        elemento.GetComponent<Drop>().tipoDeVehiculo = tipoDeVehiculo;
                    }
                }
                if (elemento.GetComponent<Drag>() != null)
                {
                    elemento.GetComponent<Drag>().miSonido = sonidos[i];
                    elemento.GetComponent<Drag>().audioS = reproductor.GetComponent<AudioSource>();
                }
            }
            if (sonDrop)
            {
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                for (int i = 0; i< elementosCreados.Length; i++)
                {
                    elementosCreados[i].transform.position = posiciones[i].position;
                    elementosCreados[i].transform.SetParent(posiciones[i]);
                    //elementosCreados[i].transform.localScale = new Vector3(30, 30, 30);
                    print(elementosCreados[i].transform.localScale);
                    if (variante == 2)
                    {
                        elementosCreados[i].GetComponent<Drop>().posActivador = posiciones[i].transform.Find("1").transform;
                    }
                }
                if (variante == 2)
                {
                    print("este es");
                    GameObject.FindGameObjectWithTag("AnimadorVehiculos").GetComponent<AnimarVehiculos>().Iniciar();
                }
            }
            
        } else
        {
            receptoresCreados = new GameObject[imagenes.Length];
            for (int i = 0; i < imagenes.Length; i++)
            {
                Sprite[] temporales = imagenes[i].frames;
                GameObject elemento = Instantiate(prefab, posiciones[0].position, Quaternion.identity);
                elemento.transform.localScale = posiciones[0].localScale;
                elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
                elemento.GetComponent<Respuesta>().respuesta = i;
                receptoresCreados[i] = elemento;
                if (elemento.GetComponent<Drop>() != null)
                {
                    sonDrop = true;
                    elementosCreados[i] = elemento;
                    elemento.SetActive(false);
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
            if (sonDrop)
            {
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                System.Array.Sort(elementosCreados, RandomSortGameObject);
                for (int i = 0; i < elementosCreados.Length; i++)
                {
                    elementosCreados[i].transform.position = posiciones[0].position;
                }
                elementosCreados[0].SetActive(true);
                receptoresCreados = elementosCreados;
            }
            
        }
    }

    void CreateSpritesText (Transform[] posiciones, SpriteAsset[] imagenes, GameObject prefab, AudioClip[] sonidos, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        receptoresCreados = new GameObject[imagenes.Length];
        GameObject[] elementosCreados = new GameObject[imagenes.Length];
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
            receptoresCreados[i].SetActive(false);
        }
        System.Array.Sort(receptoresCreados, RandomSortGameObject);
        System.Array.Sort(receptoresCreados, RandomSortGameObject);
        System.Array.Sort(receptoresCreados, RandomSortGameObject);
        receptoresCreados[0].SetActive(true);
        posicionListaReceptores = 0;
    }

    void CreateSpritesMemoria(Transform[] posiciones, SpriteAsset[] imagenes1, SpriteAsset[] imagenes2, GameObject prefab, AudioClip flip, GameObject reproductor)
    {
        int n = 0;
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
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
                elemento2.GetComponent<Memo>().audioS = reproductor.GetComponent<AudioSource>();
            }
        }
    }

    void CreateSpritesSonidos(Transform[] posiciones, SpriteAsset[] imagenes, SpriteAsset[] animaciones, AudioClip[] audios, GameObject prefab, AudioClip[] sonidosCorrecto, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
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
                elemento.GetComponent<Sonido>().frames = animaciones[i].frames;
                play.GetComponent<PlaySonidos>().elementosSonido[i] = elemento.GetComponent<Sonido>();
                if (sonidosCorrecto != null)
                {
                    elemento.GetComponent<Sonido>().miSonido = sonidosCorrecto[i];
                    elemento.GetComponent<Sonido>().audioS = reproductor.GetComponent<AudioSource>();
                }                
            }            
            play.GetComponent<PlaySonidos>().sonidos[i] = audios[i];
            play.GetComponent<PlaySonidos>().Iniciar();
        }
    }

    void CreateSpritesCanchas(Transform[] posiciones, SpriteAsset[] imagenes, GameObject prefab, SpriteAsset[] animaciones, AudioClip[] sonidos, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        for (int i = 0; i < posiciones.Length; i++)
        {
            Sprite[] temporales = imagenes[i].frames;
            Sprite[] temporales2 = animaciones[i].frames;
            GameObject elemento = Instantiate(prefab, posiciones[i].position, Quaternion.identity);
            elemento.transform.localScale = posiciones[i].localScale;
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

    void CreateSpritesDictado(Transform posicion, Transform posicion2, SpriteAsset[] imagenes, GameObject prefab, GameObject[] palabras, AudioClip[] sonidos, GameObject reproductor)
    {
        GameObject[] imagenesCreadas = new GameObject[imagenes.Length];
        GameObject[] palabrasCreadas = new GameObject[imagenes.Length];
        CheckDictado CD = reproductor.GetComponent<CheckDictado>();
        CD.sonidos = sonidos;
        for (int i = 0; i < imagenes.Length; i++)
        {
            Sprite[] temporales = imagenes[i].frames;
            GameObject elemento = Instantiate(prefab, posicion.position, Quaternion.identity);
            elemento.name = imagenes[i].name;
            elemento.GetComponent<SpriteRenderer>().sprite = temporales[0];
            elemento.GetComponent<ImagenDictado>().frames = temporales;
            imagenesCreadas[i] = elemento;

            GameObject elemento2 = Instantiate(palabras[i], posicion2.position, Quaternion.identity);
            palabrasCreadas[i] = elemento2;
        }

        CD.palabras = palabrasCreadas;
        CD.respuestas = imagenesCreadas;
        CD.Iniciar();
    }

    void CreateSpritesRompecabezas(Transform[] posiciones, Transform completo, Sprite imagen, Sprite[] piezas, AudioClip sonidoInicial, AudioClip sonidoFinal, GameObject reproductor)
    {
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        System.Array.Sort(posiciones, RandomSort);
        PuzzleCompleto Pc = reproductor.GetComponent<PuzzleCompleto>();
        print(Pc.gameObject.name);
        Pc.sonido = sonidoFinal;
        Pc.palabra = sonidoInicial;
        int respuesta = 0;
        completo.GetComponent<SpriteRenderer>().sprite = imagen;
        foreach (Transform pieza in posiciones)
        {
            pieza.GetComponent<SpriteRenderer>().sprite = piezas[respuesta];
            pieza.GetComponent<Respuesta>().respuesta = respuesta;
            respuesta++;
        }
        Pc.Iniciar();
    }

    int RandomSort(Transform a, Transform b)
    {
        return Random.Range(-1, 2);
    }

    int RandomSortGameObject (GameObject a, GameObject b)
    {
        return Random.Range(-1, 2);
    }

    public void RespuestaCorrecta(Vector3 posiParticulas)
    {
        //print("correcto!!!!!");
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
            terminadoPorPuntaje = true;
            ganar.PlayDelayed(1f);
            Invoke("TerminarMinijuego", 2f);
        }
    }

    public void Error ()
    {
        error.Play();
    }

    void TerminarMinijuego ()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        puntaje = 0;
        //print("Terminado el juego" + nombreMinijuego);
        SceneManager.UnloadSceneAsync(nombreMinijuego);
        MGD = null;
        Or = null;
        maxPuntaje = 0;
        creado = false;
        OnDisableGame.Invoke();
        temporalFake = false;
        if (terminadoPorPuntaje){
            //InterfazFinMinijuego.SetActive(true);
            InterfazFinMinijuego.GetComponent<ManagerAnimations>().OnAnimationIn();
            GetComponent<Tiempo>().Terminar();
            GetComponent<Tiempo>().Guardar(tempLvl, TempLenghtLvls);
            if (SwitchButtonEndGame) {
                InterfazFinMinijuego.transform.Find("LunaTerminada").GetComponent<ScaleAnimationInOut>().InAnimation();
                siguienteNivel.GetComponent<ScaleAnimationInOut>().OutAnimation();
            }
            else {
                siguienteNivel.GetComponent<ScaleAnimationInOut>().InAnimation();
                InterfazFinMinijuego.transform.Find("LunaTerminada").GetComponent<ScaleAnimationInOut>().OutAnimation();
            }
        }
        
    }

    void CambiarReceptor ()
    {
        posicionListaReceptores++;
        receptoresCreados[posicionListaReceptores].SetActive(true);
    }
    
    public void SetNextLevelButton (ListaMinigames lm, int ind)
    {
        siguienteNivel = InterfazFinMinijuego.transform.Find("Siguiente").GetComponent<ButtonToController>();
        //siguienteNivel.gameObject.SetActive(true);
        //InterfazFinMinijuego.transform.Find("LunaTerminada").gameObject.SetActive(false);
        //InterfazFinMinijuego.transform.Find("LunaTerminada").GetComponent<ScaleAnimationInOut>().OutAnimation();
        siguienteNivel.Lista = lm;
        siguienteNivel.index = ind + 1;
        TempLenghtLvls = lm.lista.Length;
        tempLvl = ind;
        _Slider[moonSlider].GetComponentInParent<Slider>().value = ind;
        if (siguienteNivel.index > lm.lista.Length - 1) {
            //siguienteNivel.gameObject.SetActive(false);
            //siguienteNivel.GetComponent<ScaleAnimationInOut>().OutAnimation();
            //InterfazFinMinijuego.transform.Find("LunaTerminada").GetComponent<ScaleAnimationInOut>().InAnimation();
            //InterfazFinMinijuego.transform.Find("LunaTerminada").gameObject.SetActive(true);
            SwitchButtonEndGame = true;
        }
        else {
            SwitchButtonEndGame = false;
            siguienteNivel.GetComponent<SimpleDelay>().index = lm.lista[ind].Ind;// esta parte deberia eljir el tutorial
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

    public void Swap(int moonIndex) {
        switch (moonIndex) {
            case 0:
                _Slider[0].gameObject.SetActive(true);
                _Slider[1].gameObject.SetActive(false);
                _Slider[moonSlider].GetComponentInParent<Slider>().maxValue = 10;
                moonSlider = moonIndex;
                break;
            case 1:
                _Slider[0].gameObject.SetActive(false);
                _Slider[1].gameObject.SetActive(true);
                _Slider[moonSlider].GetComponentInParent<Slider>().maxValue = 7;
                moonSlider = moonIndex;
                break;
        }
    }
}
