using System.IO.MemoryMappedFiles;
using UnityEngine;

public class Penguincontroller : MonoBehaviour
{
    public float Speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;
    public int maxJumps = 2;
    private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Vector2 screenBounds;
    private float playerHalfWidth;
    private float xPosLastFrame;
    [SerializeField] public float moveSpeed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool movingLeft = Input.GetKey(KeyCode.A);
        bool movingRight = Input.GetKey(KeyCode.D);

        if (movingLeft)
        {
            rb.linearVelocity = new Vector2(-Speed, rb.linearVelocity.y);
            if (spriteRenderer != null)
                spriteRenderer.flipX = true; // Повернуть влево
        }
        else if (movingRight)
        {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);
            if (spriteRenderer != null)
                spriteRenderer.flipX = false; // Повернуть вправо
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-Speed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(Speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }


        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    //    HandleMovement();
    //    ClampMovement();
    //    FlipCharacterX();
    //}
    //private void FlipCharacterX()
    //{ 
    //    if (transform.position.x > xPosLastFrame)
    //    {
    //        spriteRenderer.flipX = false; // Facing right
    //    }
    //    else if (transform.position.x < xPosLastFrame)
    //    {
    //        spriteRenderer.flipX = true; // Facing left
    //    }
    //    xPosLastFrame = transform.position.x;
    //}

    //private void ClampMovement()
    //{
    //    float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
    //    Vector2 pos = transform.position; //get the current position
    //    pos.x = clampedX; //Reassign the x value to the clamped position
    //    transform.position = pos; //update the position
    //}

    //private void HandleMovement()
    //{
    //    //Input will store a value between -1 and +1
    //    //GetAxisRaw() takes exactly -1 or +1
    //    //GetAxis() takes a value between ansd up to -1 and +1 (useful for acceleration)
    //    //Getting the axis is MemoryMappedFile to A/D, left/right arrow and joystick left/right
    //    float input = Input.GetAxis("Horizontal");
    //    movement.x = input * Speed * Time.deltaTime;
    //    transform.Translate(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}