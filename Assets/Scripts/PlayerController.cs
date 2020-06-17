using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Pirvate Inspector Variables

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.00f;
    [SerializeField] private Transform groundCheckPos;   // Gound check overlapcicle position
    [SerializeField] private float groundCheckRadious;    // Ground Check OverlapCircle radius
    [SerializeField] private LayerMask whatIsGround;      // Ground Later Mask             

    //Private variables

    private Rigidbody2D rBody;
    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update for physics
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        //Check if I am on the ground

        isGrounded = GroundCheck();

        //Jump code goes here
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            //JUMPING
            rBody.AddForce(new Vector2(0.0f, jumpForce));
        } 
            
        //Debug.Log("Horizontal: " + horiz);

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

    }

    private bool GroundCheck()   
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadious, whatIsGround);
    }
}
