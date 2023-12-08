using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    private LevelController levelController;
    private PlayerController playerController;
    private PlayerController playerController2;
    private DataKeeper dataKeeper;
    public GameObject player;
    public GameObject player2;
    public int dieScene;

    public void Start()
    {
        levelController = LevelController.Instance;
        dataKeeper = DataKeeper.Instance;

        //player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        playerController2 = player2.GetComponent<PlayerController>();
    }
    void Update()
    {
        Debug.Log("Life: " + dataKeeper.preLifeCount);
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
        if (other.gameObject.CompareTag("Player"))
        {
            levelController.CountLife();
            playerController.Start();
        }
        //if other gameobect name is Player2
        if (other.gameObject.name == "Player2")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelController.CountLife();
            playerController.Start();
        }
        if (other.gameObject.name == "Player2")
        {
            Destroy(other.gameObject);
        }
    }
}
