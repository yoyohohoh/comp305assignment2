using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameObject player;
    int count = 0;
    void Start()
    {
        player = GameObject.Find("Player");

    }
    private void Update()
    {
        Debug.Log("Box: " + count);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("Box (" + count + ")"));
            count++;
        }
    }
}
