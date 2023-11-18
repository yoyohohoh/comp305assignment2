using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour
{
    private Animator anim;
    private bool isTouched = false;
    public GameObject CameraTrigger;

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
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched Flag");
            isTouched = true;

            other.transform.position = new Vector3(20.5f, -2.5f, 0.0f);
            //get other object's rigidbody
            Rigidbody2D otherRBody = other.gameObject.GetComponent<Rigidbody2D>();
            //freeze the rigidbody
            otherRBody.constraints = RigidbodyConstraints2D.FreezeAll;
            //access to the CameraTrigger script
            CameraTrigger = GameObject.Find("CameraTrigger");
            CameraTrigger.GetComponentInChildren<CameraTrigger>().ZoomIn();
            //access to the PlayerController script and invoke method
            other.gameObject.GetComponent<PlayerController>().IsJumped();

            //change scene after 2 seconds
            Invoke("ChangeScene", 2.0f);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
