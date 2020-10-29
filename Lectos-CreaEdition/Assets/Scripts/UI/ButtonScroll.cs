using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScroll : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private ScrollrectButtons _scrollrect;

    [SerializeField]
    private bool isDownButton;

    public void OnPointerDown(PointerEventData eventData) {
        if (isDownButton) {
            _scrollrect.ButtonRightIsPressed();
        }
        else {
            _scrollrect.ButtonLeftIsPressed();
        }
    }
}
