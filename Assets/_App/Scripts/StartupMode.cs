using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartupMode : MonoBehaviour
{
    [SerializeField] string nextMode = "Scan";

    void OnEnable()
    {
        UIController.ShowUI("Startup");
        Debug.Log("UI Startup called from OnEnable");
    }

    // Update is called once per frame
    void Update()
    {
        if (ARSession.state ==
            ARSessionState.Unsupported)
        {
            InteractionController.EnableMode("NonAR");
        }
        else if (ARSession.state >= ARSessionState.Ready)
        {
            InteractionController.EnableMode(nextMode);
        }
    }
}