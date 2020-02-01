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

    // shooting 
    public GameObject projectileToRight, projectileToLeft;
    Vector2 projectilePosition;
    public float fireRate = 0.5f;
    float nextFire = 0.5f;

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
        // shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
        /*// shooting
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }*/


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

    void Fire()
    {
        Debug.Log("Firing");
        projectilePosition = transform.position;

        if (isFacingRight)
        {
            projectilePosition += new Vector2(1f, 0f);
            GameObject projectile = Instantiate(projectileToRight, projectilePosition, Quaternion.identity);
            projectile.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            projectilePosition += new Vector2(-1f, 0f);
            GameObject projectile = Instantiate(projectileToLeft, projectilePosition, Quaternion.identity);
            projectile.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            this.health -= 10;
            Mathf.Clamp(this.health, 0, 100);
            Vector2 newScale = this.fullFillAmount.localScale;
            Mathf.Clamp01(newScale.x);
            newScale.x -= amount / 10;
            this.fullFillAmount.localScale = newScale;
        }
    }
}
