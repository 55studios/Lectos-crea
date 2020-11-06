using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollrectButtons : MonoBehaviour
{
    private ScrollRect ScrollRect;
    private bool _mouseDown;
    private bool _buttonLeft;
    private bool _buttonRight;

    void Start()
    {
        ScrollRect = GetComponent<ScrollRect>();
    }

    public void ButtonRightIsPressed() {
        _mouseDown = true;
        _buttonRight = true;
    }

    public void ButtonLeftIsPressed() {
        _mouseDown = true;
        _buttonLeft = true;

    }

    private void ScrollRight() {
        if (Input.GetMouseButtonUp(0)) {
            _mouseDown = false;
            _buttonRight = false;
        }
        else {
            ScrollRect.horizontalNormalizedPosition += 0.01f;
        }

    }

    private void ScrollLeft() {
        if (Input.GetMouseButtonUp(0)) {
            _mouseDown = false;
            _buttonLeft = false;
        }
        else {
            ScrollRect.horizontalNormalizedPosition -= 0.01f;
        }
    }

    private void Update() {
        if (_mouseDown) {
            if (_buttonLeft) {
                ScrollLeft();
            }
            else if (_buttonRight) {
                ScrollRight();
            }
        }
    }
}
