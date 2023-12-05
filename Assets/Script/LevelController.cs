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

    //private variable
    private int totalItemsQty = 0, itemsCollectedQty = 0;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    
    }
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
        //Debug.Log("Total items: " + totalItemsQty);
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        itemsUIText.text = "X " + itemsCollectedQty;
    }


    public void PickedUpItem()
    {
        itemsCollectedQty++;
        Debug.Log("Items collected: " + itemsCollectedQty);
        UpdateItemUI();
    }

    //public void CheckLevelEnd()
    //{
    //    if(itemsCollectedQty == totalItemsQty)
    //    {
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    }
    //}
}
