using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    
    private int count;
    GameObject player;
    PlayerController playerController;
    

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    public void GameOver()
    {
        playerController.Start();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            Destroy(GameObject.Find("Life (" + count + ")"));
            GameOver();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            count++;
            Destroy(GameObject.Find("Life (" + count + ")"));
            GameOver();
        }
    }



}
