using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersControllerAnimations : MonoBehaviour
{
    public GameObject Lecto;
    public GameObject Lectina;


    private Animator _LectoAnimator;
    private Animator _LectinaAnimator;


    void Start(){
        _LectoAnimator = Lecto.GetComponent<Animator>();
        _LectinaAnimator = Lectina.GetComponent<Animator>();

        Invoke("InMainRoom", 0.5f);
    }

    public void InMainRoom() {
        _LectoAnimator.SetTrigger("InMainRoom");
        _LectinaAnimator.SetTrigger("StartAnim");
    }

    public void NextRoomLeft(float delay) {
        StartCoroutine(NRL(delay));
    }

    public void BackMainRoom(float delay) {
        StartCoroutine(BRM(delay));
    }

    public void NextRoomRigth(float delay) {
        StartCoroutine(NRR(delay));
    }
    IEnumerator NRL(float delay) {
        yield return new WaitForSeconds(delay);
        _LectoAnimator.SetTrigger("NextRoom");
    }

    IEnumerator BRM(float delay) {
        yield return new WaitForSeconds(delay);
        _LectoAnimator.SetTrigger("BackRoom");
    }

    IEnumerator NRR(float delay) {
        yield return new WaitForSeconds(delay);
        _LectinaAnimator.SetTrigger("OutRoom");
        yield return new WaitForSeconds(2);
        _LectinaAnimator.SetTrigger("StartAnim");
    }
}
