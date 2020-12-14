using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class SimpleDebug : MonoBehaviour
{
    //public DOTweenPath _path;
    //public Transform newPosition;
    //public int wayPoints;
    //public UnityEvent WayPointEvent;
    //private int counter;
    //private Tween t;

    //private void Start() {
    //    t = _path.GetTween();
    //    t.OnWaypointChange(WPSCallback);
    //}
    //public void Debugger() {
    //    _path.transform.DOPath(_path.path, 1).SetLookAt(newPosition);
    //    _path.orientType = DG.Tweening.Plugins.Options.OrientType.LookAtTransform;
    //    Debug.Log(_path.orientType);
    //    counter++;
    //    Debug.Log("Working " + counter);
    //}

    //void WPSCallback(int waypoinsIndex) {
    //    if (waypoinsIndex == wayPoints) {
    //        WayPointEvent.Invoke();
    //        Debugger();
    //    }
    //}

    public HandlerLevelsData data;
    public int level;
    public bool activableLevel;
    [Range(0,3)]
    public int stars;
    public float record;

    public void EventButton() {
        //data.WriteDataAndUpdate(level,activableLevel,stars,record);
    }
}
