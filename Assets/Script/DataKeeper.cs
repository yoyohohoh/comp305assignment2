using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
    private LevelController levelController;
    public int prePickedupItems;
    public int preEnemyBeat;
    public int preLifeCount;
    public int currentScecneIndex;
    public int dieScene;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void ResetNumber()
    {
        NumberOfItems(0);
        NumberOfEnemies(0);
        NumberOfLives(0);
    }

    private void FixedUpdate()
    {
        levelController = LevelController.Instance;
        levelController.itemsCollectedQty = DataKeeper.Instance.prePickedupItems;
        levelController.enemyBeat = DataKeeper.Instance.preEnemyBeat;
        levelController.lifeCount = DataKeeper.Instance.preLifeCount;
    }

    private void Update()
    {
        NumberOfItems(levelController.itemsCollectedQty);
        NumberOfEnemies(levelController.enemyBeat);
        NumberOfLives(levelController.lifeCount);
    }

    public void NumberOfItems(int totalItems)
    {
        DataKeeper.Instance.prePickedupItems = totalItems;
    }
    public void NumberOfEnemies(int totalEnemies)
    {
        DataKeeper.Instance.preEnemyBeat = totalEnemies;
    }

    public void NumberOfLives(int totalLives)
    {
        DataKeeper.Instance.preLifeCount = totalLives;
    }

    public void DieScene(int scene)
    {
        dieScene = scene;
        Debug.Log("Die scene: " + dieScene);

    }

}
