using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    [SerializeField]
    string link;

    public void Open ()
    {
        Application.OpenURL(link);
    }
}
