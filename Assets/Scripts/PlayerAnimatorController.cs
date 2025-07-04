// +
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform transform;
    

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        transform = player.transform;
    }

    void Update()
    {
        ResetAnimations();
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    private void ResetAnimations()
    {
        transform.localScale = new Vector3(0.51f, 0.51f, 0.51f);
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("Idle", true);
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);
    }

    private void HandleHorizontalMovement()
    {
        float velocityX = Mathf.Round(rb.linearVelocity.x);

        if (velocityX > 0)
        {
            SetAnimationState("Right", true);
        }
        else if (velocityX < 0)
        {
            SetAnimationState("Left", true);
        }
        else
        {
            animator.SetBool("Idle", true); 
        }
    }

    private void HandleVerticalMovement()
    {
        float velocityY = Mathf.Round(rb.linearVelocity.y);

        if (velocityY > 0)
        {
            SetAnimationState("Jump", true);
            transform.localScale = new Vector3(0.47f, 0.51f, 0.51f);
            PlayJumpSound();
        }
        else if (velocityY < 0)
        {
            SetAnimationState("Fall", true);
            transform.localScale = new Vector3(0.47f, 0.51f, 0.51f);
        }
    }

    private void SetAnimationState(string stateName, bool value)
    {
        animator.SetBool(stateName, value);
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}
