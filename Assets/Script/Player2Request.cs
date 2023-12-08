using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player2Request : MonoBehaviour
{
    public GameObject player2;
    public Button button;
    public GameObject instruction;
    public UnityEvent _action;


    public void HideInstruction()
    {
        instruction.SetActive(false);
    }
    public void RequestPlayer()
    {

        //if there is no player 2 in the game
        if (GameObject.Find("Player2") == null && player2 != null)
        {
            Debug.Log("Request Player 2");
            _action.Invoke();
            Invoke("HideInstruction", 2.0f);
            player2.SetActive(true);
            
            button.GetComponent<Image>().color = new Color(200 / 255f, 200 / 255f, 200 / 255f);
        }
        else
        {
            Debug.Log("Player 2 is already in the game");
        }
    }
}
