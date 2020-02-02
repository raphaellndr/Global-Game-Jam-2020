using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;
    [SerializeField] public LayerMask groundLayerMask;
    private bool isJumping;

    private float jumpTimeCounter;
    public float jumpTime;

    private bool isFacingRight = true;

    public bool job; //false>mécano         true>scientifique

    // health
    public int health = 100;
    public Transform fullFillAmount;
    public float amount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        amount = fullFillAmount.localScale.x;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    void Update()
    {
        // moving 
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundLayerMask);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }
        else isJumping = false;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (moveInput < 0)
        {
            isFacingRight = false;
        }
        if (moveInput > 0)
        {
            isFacingRight = true;
        }        

        // death 
        if (this.health == 0)
        {
            //do something
        }        
    }
}
