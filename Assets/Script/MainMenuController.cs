using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private DataKeeper dataKeeper;
    private LevelController levelController;

    void Start()
    {
        dataKeeper = DataKeeper.Instance;
        levelController = LevelController.Instance;
    }
    public void StartGame()
    {
        //SceneManager.LoadScene("Level1");
        //dont use above to avoid human error
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void RestartGame()
    {
        dataKeeper.ResetNumber();
        levelController.ResetNumber();
        SceneManager.LoadScene(dataKeeper.dieScene);
    }

    public void QuitGame()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
