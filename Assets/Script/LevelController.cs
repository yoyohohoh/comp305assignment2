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
    public int itemsCollectedQty;

    //private variable
    private int totalItemsQty = 0;
    private DataKeeper dataKeeper;
 


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
           
        }
    
    }
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;        
        UpdateItemUI();
    }


    private void UpdateItemUI()
    {
        itemsUIText.text = itemsCollectedQty.ToString();
    }


    public void PickedUpItem()
    {
        itemsCollectedQty++;
        UpdateItemUI();
    }

}
