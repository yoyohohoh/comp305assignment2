using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private int count = 0;
    GameObject player;
    PlayerController playerController;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    public void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //player.transform.position = playerController.startPosition;
        //play the playercontroller script fromt he beginning
        playerController.Start();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameOver();
            count++;
            Destroy(GameObject.Find("Life (" + count + ")"));
        }
    }



}
