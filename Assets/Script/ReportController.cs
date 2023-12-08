using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportController : MonoBehaviour
{
    private int lifeCount;
    private int coinsCount;
    private int enemyBeat;
    private int reward;
    private GameObject Star;
    public float delay = 2f;
    private LevelController levelController;

    void Start()
    {
        levelController = LevelController.Instance;
        coinsCount = DataKeeper.Instance.prePickedupItems;
        enemyBeat = DataKeeper.Instance.preEnemyBeat;
        lifeCount = DataKeeper.Instance.preLifeCount;
        //Invoke("DestoryReport", delay);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Life: " + lifeCount);
        Debug.Log("Coins: " + coinsCount);
        Debug.Log("Enemy: " + enemyBeat);
        ActivateStar(Result());
    }

    private int Result()
    {

        if(enemyBeat >= 15 || coinsCount >= 90 || lifeCount == 0)
        {
            reward = 3;
        }
        else if(enemyBeat >= 10 && coinsCount >= 60 && lifeCount <= 2)
        {
            reward = 3;
        }
        else if (enemyBeat <= 1 || coinsCount <= 12)
        {
            reward = 1;
        }
        else
        {
            reward = 2;
        }

        return reward;
    }

    private void ActivateStar(int reward)
    {

        Star = GameObject.Find("Star" + reward);
        Star.GetComponentInChildren<SpriteRenderer>().enabled = true;

    }

    private void DestoryReport()
    {
        Debug.Log("Destroy Report");
        Destroy(this.gameObject);
    }




}
