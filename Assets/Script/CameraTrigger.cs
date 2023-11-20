using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraToActivate;
    [SerializeField] private GameObject cameraOut;

    public VirtualCameraController vCameraController;

    public void ZoomIn()
    {
        vCameraController.TransitionTo(cameraToActivate);
    }

    public void ZoomOut() 
    { 
        vCameraController.TransitionTo(cameraOut);
    }


}
