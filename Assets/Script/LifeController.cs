using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    private LevelController levelController;
    private PlayerController playerController;
    private DataKeeper dataKeeper;
    private GameObject player;
    public int dieScene;

    public void Start()
    {
        levelController = LevelController.Instance;
        dataKeeper = DataKeeper.Instance;

        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelController.CountLife();
            playerController.Start();
        }
    }
}
