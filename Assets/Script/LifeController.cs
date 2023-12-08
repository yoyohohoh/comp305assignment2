using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    private LevelController levelController;
    private PlayerController playerController;
    private PlayerController2 playerController2;
    private DataKeeper dataKeeper;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject player2;
    [SerializeField] public int dieScene;

    public void Start()
    {
        levelController = LevelController.Instance;
        dataKeeper = DataKeeper.Instance;
        FindPlayer();

    }
    private void FindPlayer()
    {
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");

        if (player != null || player2 != null)
        {
            playerController = player.GetComponent<PlayerController>();
            playerController2 = player2.GetComponent<PlayerController2>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }
    }
    void Update()
    {


        //Debug.Log("Life: " + dataKeeper.preLifeCount);
        if (dataKeeper.preLifeCount >= 5)
        {
            Debug.Log("Game Over");
            dieScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Get");
            dataKeeper.DieScene(dieScene);
            Debug.Log("Sent");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.name == "Player")
        {
            levelController.CountLife();
            playerController.Start();
        }
        if (other.gameObject.name == "Player2")
        {
            GameObject.Find("DieSound").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.name == "Player")
        {
            levelController.CountLife();
            playerController.Start();
        }
        if (other.gameObject.name == "Player2")
        {
            GameObject.Find("DieSound").GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
        }
    }
}
