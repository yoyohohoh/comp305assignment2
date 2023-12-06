using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
    private LevelController levelController;
    public int prePickedupItems;

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


    private void Start()
    {

    }

    private void FixedUpdate()
    {
        levelController = LevelController.Instance;
        levelController.itemsCollectedQty = DataKeeper.Instance.prePickedupItems;
    }

    private void Update()
    {
        NumberOfItems(levelController.itemsCollectedQty);
    }

    public void NumberOfItems(int totalItems)
    {
        DataKeeper.Instance.prePickedupItems = totalItems;
        Debug.Log("Previous items: " + totalItems);
    }   
}
