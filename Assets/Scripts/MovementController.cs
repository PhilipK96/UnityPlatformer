using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 2;
    public Joystick joystick;
    
    private bool isGrounded;
    private float moveInput;
    private Rigidbody2D rb;
    private float jumpforce = 30;

    public MovementController(Rigidbody2D rb, Joystick joystick){
        this.rb = rb;
        this.joystick = joystick;   
    }

    public void Jump(){
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
        Vector2 difference = Vector2.up * jumpforce;
        rb.linearVelocity = rb.linearVelocity + difference;
    }

    public Rigidbody2D HandleInput(Rigidbody2D rb)
    {
        moveInput = joystick.Horizontal;
        Vector2 difference = new Vector2(moveInput * speed, 0);
        rb.linearVelocity = rb.linearVelocity + difference;
        float x_axis_speed = Mathf.Clamp(rb.linearVelocity[0], -20, 20); 
        rb.linearVelocity = new Vector2(x_axis_speed, rb.linearVelocity[1]);
        return rb;
    }
}