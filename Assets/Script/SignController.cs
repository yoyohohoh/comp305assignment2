using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    public GameObject CameraTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched Sign");
            
            CameraTrigger = GameObject.Find("CameraTrigger (1)");
            CameraTrigger.GetComponentInChildren<CameraTrigger>().ZoomIn();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            CameraTrigger = GameObject.Find("CameraTrigger (1)");
            CameraTrigger.GetComponentInChildren<CameraTrigger>().ZoomOut();
        }
    }
}
