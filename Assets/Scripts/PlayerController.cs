using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;

    public float moveSpeed = 50;
    public float jumpForce = 15;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    float moveDirection;

    SpriteRenderer sr;

    public bool isGrounded = true;
    public bool canDoubleJump;
    public bool didJump;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);


        if (isGrounded)
            canDoubleJump = true;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, whatIsGround);

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                didJump = true;
            }
            else
            {
                if (canDoubleJump && didJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                    didJump = false;
                }

            }
        }

        if (isGrounded)
        {
            if (rb.velocity.x > 0 || rb.velocity.x < 0)
            {
                anim.SetBool("isMoving", true);
            }
            else if (rb.velocity.x == 0)
            {
                anim.SetBool("isMoving", false);
            }
        }

    }
}

