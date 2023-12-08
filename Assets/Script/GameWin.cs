using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    private void Start()
    {

        GameObject.Find("AudioManager").GetComponent<AudioSource>().enabled = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //UI Text "Win" appear
            //GameObject.Find("Win").GetComponent<Canvas>().enabled = true;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().enabled = false;
        }
    }
}
