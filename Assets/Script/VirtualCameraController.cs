using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraController : MonoBehaviour
{
    public List<GameObject> virtualCameras;
    void Start()
    {
        virtualCameras.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            virtualCameras.Add(transform.GetChild(i).gameObject);
        }
    }

    public void TransitionTo(GameObject cameraToTransitionTo)
    {
        foreach (GameObject g in virtualCameras)
        {
            if (g == cameraToTransitionTo)
            {
                g.GetComponent<CinemachineVirtualCamera>().Priority = 10;
            }
            else
            {
                g.GetComponent<CinemachineVirtualCamera>().Priority = 5;
            }
        }
    }
}
