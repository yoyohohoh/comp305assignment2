using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystemContoller : MonoBehaviour
{
    int count;
    public int dieScene;
    private DataKeeper dataKeeper;
    // Start is called before the first frame update
    void Start()
    {
        dataKeeper = DataKeeper.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (dataKeeper.preLifeCount > 5)
        {
            Debug.Log("Game Over");
            dieScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Get");
            dataKeeper.DieScene(dieScene);
            Debug.Log("Sent");
            SceneManager.LoadScene("GameOver");
        }
    }
}
