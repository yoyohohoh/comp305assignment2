using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    private static LevelController _instance;
    public static LevelController Instance
    {
        get
        {
            return _instance;
        }
    }

    //public variable
    [SerializeField] public Text itemsUIText;
    [SerializeField] public Text enemyUIText;
    [SerializeField] public Text lifeUIText;
    public int itemsCollectedQty;
    public int enemyBeat;
    public int lifeCount;
    public int dieScene;
 
    //private variable
    private int totalItemsQty = 0;
    private DataKeeper dataKeeper;

    public void ResetNumber()
    {
        itemsCollectedQty = 0;
        enemyBeat = 0;
        lifeCount = 0;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            itemsCollectedQty = DataKeeper.Instance.prePickedupItems;
            enemyBeat = DataKeeper.Instance.preEnemyBeat;
            lifeCount = DataKeeper.Instance.preLifeCount;

        }
    
    }
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;        
        UpdateItemUI();
        UpdateEnemyUI();
        UpdateLifeUI();

    }

    private void UpdateItemUI()
    {
        itemsUIText.text = itemsCollectedQty.ToString();
    }

    private void UpdateEnemyUI()
    {
        enemyUIText.text = enemyBeat.ToString();
    }

    private void UpdateLifeUI()
    {
        lifeUIText.text = lifeCount.ToString();
    }


    public void PickedUpItem()
    {
        itemsCollectedQty++;
        UpdateItemUI();
    }

    public void BeatedEnemy()
    {
        enemyBeat++;
        UpdateEnemyUI();
    }

    public void CountLife()
    {
        lifeCount++;
        UpdateLifeUI();
    }



}
