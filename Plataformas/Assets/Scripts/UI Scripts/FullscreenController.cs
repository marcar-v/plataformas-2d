using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenController : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }
    public void ActivateFullscreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}
