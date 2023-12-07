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
    public int itemsCollectedQty;
    public int enemyBeat;
 
    //private variable
    private int totalItemsQty = 0;
    private DataKeeper dataKeeper;

    public void ResetNumber()
    {
        itemsCollectedQty = 0;
        enemyBeat = 0;
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

        }
    
    }
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;        
        UpdateItemUI();
        UpdateEnemyUI();
    }


    private void UpdateItemUI()
    {
        itemsUIText.text = itemsCollectedQty.ToString();
    }

    private void UpdateEnemyUI()
    {
        enemyUIText.text = enemyBeat.ToString();
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



}
