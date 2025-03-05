using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ForceControllers : MonoBehaviour
{
    public GameObject RightController;

    public InputActionAsset inputActions;
    void Start()
    {
        // if (XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "OpenXR")
        // {
        //     Debug.Log("Meta Link Detected! Restarting XR Subsystems...");
        //     StartCoroutine(RestartXR());
        // }
        //
//        RightController.SetActive(true);
//        StartCoroutine(RestartXR());
    }

    private IEnumerator RestartXR()
    {
        UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        yield return null;
        UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.InitializeLoader();
        yield return null;

        Debug.Log("Meta Link XR Subsystems Restarted 🔥");
    }
}

