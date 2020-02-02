using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float sprintSpeed;

    private bool facingRight;

    public float jumpForce;

    private bool isGrounded;

    public Transform feetPosition;

    public float checkRadius;

    [SerializeField] public LayerMask groundLayerMask;
    private bool isJumping;

    private float jumpTimeCounter;
    public float jumpTime;

    public bool job; //false>mécano         true>scientifique

    // health
    public int health = 100;
    public Transform fullFillAmount;
    public float amount;


    void Start()
    {
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal, movementSpeed);

        Sprint(horizontal);

        Flip(horizontal);

        HandleLayers();
    }

    void Update()
    {
        // moving 
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundLayerMask);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            myRigidBody.velocity = Vector2.up * jumpForce;
            myAnimator.ResetTrigger("jump");
        }


        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                myRigidBody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        else isJumping = false;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (isGrounded && isJumping)
        {
            isGrounded = false;
            myAnimator.SetTrigger("jump");
        }

        // death 
        if (this.health == 0)
        {
            //do something
        }


    }

    private void HandleMovement(float horizontal, float speed)
    {
        myRigidBody.velocity = new Vector2(horizontal*speed, myRigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal*speed));
    }

    private void Sprint(float horizontal)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            HandleMovement(horizontal, sprintSpeed);
        }

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            //On choppe le scale actuel
            Vector3 theScale = transform.localScale;
            theScale.x *= -1; //on le flip

            //on change le scale actuel par le scale flippé
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        if (myRigidBody.velocity.y <=0)
        {
            myAnimator.SetBool("land", true);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feetPosition.position, checkRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    myAnimator.ResetTrigger("jump");
                    myAnimator.SetBool("land", false);
                    return true;
                }
            }
        }
        return false;
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

}
