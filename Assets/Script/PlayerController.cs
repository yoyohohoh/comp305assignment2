using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // public variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    //show as "public" but is private actually
    //cannot access by other scripts
    //but can be changed in the inspector
    
    // private variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private bool isJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = new Vector3(-12.0f, 3f, 0.0f);
    }

    // Physics
    private void FixedUpdate()
    {
        //Debug.Log("Fixed Update Time: " + Time.deltaTime);
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //Jump
        if ( isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
            //GetComponent<AudioSource>().Play();
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Check if the sprite needs to be flipped
        if((isFacingRight && rBody.velocity.x < 0) || (!isFacingRight && rBody.velocity.x > 0))
        {
            Flip();
        }

        // conmmunicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isJumped", isJumped);
        //Debug.Log(rBody.velocity.y);
    }

    public void IsJumped()
    {
        isJumped = true;
        //flip X
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

    }

    private bool GroundCheck()
    {
        //Debug.Log("Ground Check");
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player touched " + other.gameObject.name);
        transform.transform.parent = other.transform;
    }


}
