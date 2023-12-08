using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class BoxController : MonoBehaviour
{
    public GameObject platform;
    public GameObject elevator;
    public GameObject player;
    //int count = 0;
    [SerializeField] private UnityEvent _action;
    void Start()
    {


    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Entrance")
        {
                    
            _action.Invoke();
            
            
            elevator.SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
