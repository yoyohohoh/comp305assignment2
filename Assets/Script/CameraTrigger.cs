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

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player entered trigger");
    //        vCameraController.TransitionTo(cameraToActivate);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player exited trigger");
    //        vCameraController.TransitionTo(cameraOut);
    //    }
    //}
}
