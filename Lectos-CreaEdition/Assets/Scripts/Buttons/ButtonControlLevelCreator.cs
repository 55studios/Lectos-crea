using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ButtonControlLevelCreator : MonoBehaviour
{
    private float waitTimeStart = 1.5f;
    private float waitTimeDuring = 0.8f;
    private float WaitingTimeEnd = 0.5f;

    private CreateLevel master;
    private SpriteRenderer fondo;
    private Animator transition;
    private ButtonToController controllerMiniGames;
    private GameObject parent;
    private MoveAnimationInOut moons;
    private GameObject canvasMinijuego;
    //private MoveAnimationInOut moon_2;
    //private MoveAnimationInOut moon_3;

    private void Start() {
        master = GameObject.Find("Controlador").GetComponent<CreateLevel>();
        controllerMiniGames = GetComponent<ButtonToController>();
        fondo = GameObject.Find("FondoPlaneta").GetComponent<SpriteRenderer>();
        transition = GameObject.Find("TransitionAnimation").GetComponent<Animator>();
        parent = GameObject.Find("MinijuegoTerminado");
        moons = GameObject.Find("Moons").GetComponent<MoveAnimationInOut>();
        //moon_2 = GameObject.Find("Moon_2").GetComponent<MoveAnimationInOut>();
        //moon_3 = GameObject.Find("Moon_3").GetComponent<MoveAnimationInOut>();
    }
    public void OnCLickInTransition() {
        StartCoroutine(InTransitionEvent());
    }

    public void OnCLickOutTransition() {
        StartCoroutine(OutTransitionEvent());
    }

    IEnumerator InTransitionEvent() {
        transition.SetTrigger("Out");
        yield return new WaitForSeconds(waitTimeStart);
        fondo.enabled = true;
        yield return new WaitForSeconds(waitTimeDuring);
        transition.SetTrigger("In");
        moons.InAnimation();
        //moon_2.InAnimation();
        //moon_3.InAnimation();
        canvasMinijuego = GameObject.Find("MinijuegoTerminado");
        if (canvasMinijuego != null) {
            canvasMinijuego.SetActive(false);
            master.CerrarMinijuego();
        }
    }

    IEnumerator OutTransitionEvent() {
        yield return new WaitForSeconds(waitTimeStart);
        transition.SetTrigger("Out");
        yield return new WaitForSeconds(waitTimeDuring);
        fondo.enabled = false;
        controllerMiniGames.CrearMinijuego();
        yield return new WaitForSeconds(WaitingTimeEnd);
        transition.SetTrigger("In");
    }
}
