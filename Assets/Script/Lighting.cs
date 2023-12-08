using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lighting : MonoBehaviour
{
    public GameObject lightOff;
    public GameObject lightOn;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //get Light 2d from child

            lightOn.GetComponentInChildren<Light2D>().enabled = true;
            lightOff.GetComponentInChildren<Light2D>().enabled = false;
        }
    }
}