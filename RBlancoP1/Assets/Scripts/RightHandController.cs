using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{
    public XRRayInteractor _XRRayInteractor_RightControl_Grap;
    public XRRayInteractor _XRRayInteractor_RightControl_Teleport;

    public InputActionReference RControllerTeleportAction;

    private void Start()
    {
        _XRRayInteractor_RightControl_Grap.enabled = true;
        _XRRayInteractor_RightControl_Teleport.enabled = false;
    }

    private void RightController_PalancaArribaPresionada(InputAction.CallbackContext context)
    {
        _XRRayInteractor_RightControl_Grap.enabled = false;
        _XRRayInteractor_RightControl_Teleport.enabled = true;
    }

    private void RightController_PalancaArribaLiberada(InputAction.CallbackContext context)
    {
        Invoke("HideRightHandRayInteractor", 0.005f);
    }

    public void HideRightHandRayInteractor()
    {
        _XRRayInteractor_RightControl_Grap.enabled = true;
        _XRRayInteractor_RightControl_Teleport.enabled = false;
    }

    private void OnEnable()
    {
        RControllerTeleportAction.action.performed += RightController_PalancaArribaPresionada;
        RControllerTeleportAction.action.canceled += RightController_PalancaArribaLiberada;
    }

    private void OnDisable()
    {
        RControllerTeleportAction.action.performed -= RightController_PalancaArribaPresionada;
        RControllerTeleportAction.action.canceled -= RightController_PalancaArribaLiberada;
    }

}