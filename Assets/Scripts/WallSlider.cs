// +
using UnityEngine;

public class WallSlider : MonoBehaviour
{
    private bool IsWalled_right;
    private bool IsWalled_left;

    private void Update()
    {
        WallSlide();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall_right"))
        {
            IsWalled_right = true;
            Debug.Log(IsWalled_right);
        }
        if (collision.collider.CompareTag("Wall_left"))
        {
            IsWalled_left = true;
            Debug.Log(IsWalled_left);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall_right"))
        {
            IsWalled_right = false;
            Debug.Log(IsWalled_right);
        }
        if (collision.collider.CompareTag("Wall_left"))
        {
            IsWalled_left = false;
        }
    }

    private void WallSlide()
    {
        if (WallCheck())
        {
            GetComponent<Rigidbody2D>().linearVelocityY = -0.1f;
        }
    }

    public bool WallCheck()
    {
        if (IsWalled_left || IsWalled_right)
        {
            return true;
        }
        return false;
    }

    public void FlipJump()
    { 
        if (IsWalled_left)
        {
            IsWalled_left = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 4000f));
        }

        if (IsWalled_right)
        {
            IsWalled_right = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f, 4000f));
        }
    }
}
