// +
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public HealthController health; 
    private MovementController movement;
    private float coyoteTime = 1.2f;
    private float coyoteTimeCounter;
    private bool moveToRight;
    private bool moveToLeft;
    private bool isGrounded;
    private bool isInAir = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new MovementController(rb, joystick); 
    }

    private void FixedUpdate()
    {
        if (joystick != null)
        {
            rb = movement.HandleInput(rb);
        }

        if (moveToRight)
        {
            if (isGrounded)
            {
                rb.linearVelocity += new Vector2(2, 0);
                float x_axis_speed = Mathf.Clamp(rb.linearVelocity[0], -20, 20); // x - axis speed limit
                rb.linearVelocity = new Vector2(x_axis_speed, rb.linearVelocity[1]);
            } else
            {
                rb.linearVelocityX += 0.8f;
            }
        }

        if (moveToLeft)
        {
            if (isGrounded)
            {
                rb.linearVelocity -= new Vector2(2, 0);
                float x_axis_speed = Mathf.Clamp(rb.linearVelocity[0], -20, 20); // x - axis speed limit
                rb.linearVelocity = new Vector2(x_axis_speed, rb.linearVelocity[1]);
            } else
            {
                rb.linearVelocityX -= 0.8f;
            }
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        if (!isGrounded)
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            isInAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void SetMoveToRight()
    {
        moveToRight = !moveToRight;
    }

    public void SetMoveToLeft()
    {
        moveToLeft = !moveToLeft;
    }
    

    public void Jump()
    {
        if (coyoteTimeCounter > 0f & !isInAir)
        {
            isInAir = true;
            movement.Jump();
        }
        if (GetComponent<WallSlider>().WallCheck())
        {
            GetComponent<WallSlider>().FlipJump();
        }
        coyoteTimeCounter = 0f;
    }
}