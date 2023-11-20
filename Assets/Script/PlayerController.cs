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
    public Vector2 startPosition = new Vector2(-12.0f, 3f);
    
    // private variables
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private bool isJumped = false;

    public void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = startPosition;
    }

    private void FixedUpdate()
    {
        GetComponent<PolygonCollider2D>().enabled = true;
        Movement();
        isGrounded = GroundCheck();

        //Jump
        if ( isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }


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
    }

    public void Movement()
    {
        float horiz = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

    }

    public void IsJumped()
    {
        isJumped = true;
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

    }

    private bool GroundCheck()
    {
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
        if(other.gameObject.CompareTag("Platform") || other.gameObject.layer == 6)
        { 
            transform.transform.parent = other.transform;
        }


    }



}
