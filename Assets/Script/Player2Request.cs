using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Request : MonoBehaviour
{
    public GameObject player2;

    public void RequestPlayer()
    {
        Debug.Log("Request Player 2");
        player2.SetActive(true);
    }
}
