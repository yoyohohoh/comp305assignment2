using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FlagController : MonoBehaviour
{
    private Animator anim;
    private bool isTouched = false;
    private GameObject CameraTrigger;
    public Vector2 lastPosition = new Vector2(20.5f, -2.5f);
    [SerializeField] private UnityEvent _action;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isTouched", isTouched);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.gameObject.name != "Player2")
        {
            Debug.Log("Player touched Flag");
            isTouched = true;

            other.transform.position = lastPosition;           
            GameObject.Find("Player2").transform.position = lastPosition + new Vector2(1.0f, 0.0f);
            //get other object's rigidbody
            Rigidbody2D otherRBody = other.gameObject.GetComponent<Rigidbody2D>();
            //freeze the rigidbody
            otherRBody.constraints = RigidbodyConstraints2D.FreezeAll;
            //access to the CameraTrigger script
            CameraTrigger = GameObject.Find("CameraTrigger");
            CameraTrigger.GetComponentInChildren<CameraTrigger>().ZoomIn();
            //access to the PlayerController script and invoke method
            //other.gameObject.GetComponent<PlayerController>().IsJumped();
            _action.Invoke();
            //change scene after 2 seconds
            Invoke("ChangeScene", 5.0f);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
