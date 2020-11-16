using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ButtonControlLevelCreator : MonoBehaviour
{
    private float waitTimeStart = 1.5f;
    private float waitTimeDuring = 0.8f;
    private float WaitingTimeEnd = 0.5f;

    private GameObject fondo;
    private Animator transition;
    private ButtonToController controllerMiniGames;

    private void Start() {

        controllerMiniGames = GetComponent<ButtonToController>();
        fondo = GameObject.Find("FondoPlaneta");
        transition = GameObject.Find("TransitionAnimation").GetComponent<Animator>();
    }
    public void OnCLickInTransition() {
        StartCoroutine(InTransitionEvent());
    }

    public void OnCLickOutTransition() {
        StartCoroutine(OutTransitionEvent());
    }

    IEnumerator InTransitionEvent() {
        transition.SetTrigger("In");
        yield return new WaitForSeconds(waitTimeStart);
        fondo.SetActive(false);
        yield return new WaitForSeconds(waitTimeDuring);
        fondo.SetActive(true);
    }

    IEnumerator OutTransitionEvent() {
        yield return new WaitForSeconds(waitTimeStart);
        transition.SetTrigger("Out");
        yield return new WaitForSeconds(waitTimeDuring);
        fondo.SetActive(false);
        controllerMiniGames.CrearMinijuego();
        yield return new WaitForSeconds(WaitingTimeEnd);
        transition.SetTrigger("In");
    }
}
