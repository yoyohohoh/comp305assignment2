using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportController : MonoBehaviour
{
    private int lifeCount;
    private int coinsCount;
    private int enemyBeat;

    private LevelController levelController;

    void Start()
    {
        levelController = LevelController.Instance;
        coinsCount = DataKeeper.Instance.prePickedupItems;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Life: " + lifeCount);
        Debug.Log("Coins: " + coinsCount);
        Debug.Log("Enemy: " + enemyBeat);
    }




}
