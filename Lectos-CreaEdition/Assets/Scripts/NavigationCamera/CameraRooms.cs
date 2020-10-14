using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraRooms : MonoBehaviour {
    //<sumary> agregar los puntos de los room al mismo tiempo que un nuevo room en
    //camera pro atachado <see "cref="ProCamera2DRooms"/>
    //en la mainCamera. A tener encuenta(RoomR numeros pares y RommL Numero Impares)
    //</sumary>
    #region Fields

    [SerializeField]
    GalaxiaAData gx;

    [SerializeField]
    public GameObject cameraPro;

    [SerializeField]
    public int actualPosition = 0;

    [SerializeField]
    public Transform RoomControl;

    [SerializeField]
    public Transform MainPoint;

    [SerializeField]
    public RoomOptionsRight[] RoomsR;

    [SerializeField]
    public RoomOptionsLeft[] RoomsL;

    #endregion
    int Counter;
    #region methods

    public void Awake() {
        //set room initialization
        actualPosition = 0;
        if (actualPosition == 0) {
            RoomControl.position = MainPoint.position;
        }
    }

    public void NextRoom() {
        StartCoroutine(NextCoroutineRoom());
    }

    public void PreviousRoom() {
        StartCoroutine(PreviousCoroutineRoom());
    }

    IEnumerator NextCoroutineRoom() {
        actualPosition++;
        if (actualPosition > RoomsR.Length) {
            actualPosition = RoomsR.Length;
        }
        else {
        }
        if (actualPosition == 0) {
            yield return new WaitForSeconds(RoomsR[0].DelayBeforeTransitionRoom);
            RoomsR[0].OnBeforeTransition.Invoke();
            RoomControl.position = MainPoint.position;
        }
        else if (actualPosition >= 1) {
            yield return new WaitForSeconds(RoomsR[actualPosition - 1].DelayBeforeTransitionRoom);
            RoomsR[actualPosition - 1].OnBeforeTransition.Invoke();
            RoomControl.position = RoomsR[actualPosition - 1].RoomsR.position;
        }
        else if (actualPosition <= -1) {
            if (Mathf.Abs(actualPosition) <= RoomsL.Length) {
                yield return new WaitForSeconds(RoomsL[Mathf.Abs(actualPosition) - 1].DelayBeforeTransitionRoom);
                RoomsL[Mathf.Abs(actualPosition) - 1].OnBeforeTransition.Invoke();
                RoomControl.position = RoomsL[Mathf.Abs(actualPosition) - 1].RoomsL.position;
            }
        }
    }

    IEnumerator PreviousCoroutineRoom() {
        actualPosition--;
        if (Mathf.Abs(actualPosition) > RoomsR.Length) {
            actualPosition = RoomsL.Length * -1;
        }
        if (actualPosition == 0) {
            RoomsL[0].OnBeforeTransition.Invoke();
            yield return new WaitForSeconds(RoomsL[0].DelayBeforeTransitionRoom);
            RoomControl.position = MainPoint.position;
        }
        else if (actualPosition >= 1) {
            yield return new WaitForSeconds(RoomsR[actualPosition - 1].DelayBeforeTransitionRoom);
            RoomControl.position = RoomsR[actualPosition - 1].RoomsR.position;
        }
        else if (actualPosition <= -1) {
            yield return new WaitForSeconds(RoomsL[Mathf.Abs(actualPosition) - 1].DelayBeforeTransitionRoom);
            if (Mathf.Abs(actualPosition) <= RoomsL.Length) {
                RoomControl.position = RoomsL[Mathf.Abs(actualPosition) - 1].RoomsL.position;
            }
        }

    }

    #endregion

    #region SmallObjects

    [System.Serializable]
    public class RoomOptionsRight {
        [SerializeField]
        public UnityEvent OnBeforeTransition;

        [Range(0, 20)]
        [SerializeField]
        public float DelayBeforeTransitionRoom = 1;

        [SerializeField]
        public Transform RoomsR;

    }

    [System.Serializable]
    public class RoomOptionsLeft {
        [SerializeField]
        public UnityEvent OnBeforeTransition;

        [Range(0, 20)]
        [SerializeField]
        public float DelayBeforeTransitionRoom = 1;

        [SerializeField]
        public Transform RoomsL;
    }

    #endregion

    private void Update() {
        //if (Input.GetKeyDown(KeyCode.S)) {
        //    UserInfo userSaved = new UserInfo("Pepito", "godzila123");
        //}
        //if (Input.GetKeyDown(KeyCode.C)) {
        //    UserInfo userSaved = new UserInfo(null, null);
        //}

        if (Input.GetKeyDown(KeyCode.S)) {

            gx.PlanetDataSaved(0,true,1,50);
            gx.MoonDataSaved(0,0, true, false, 1);
            gx.MinigamesDataSaved(0,0,1,false,5.6f,3,null);        }
    }
}
