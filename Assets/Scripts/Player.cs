using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Animator animator;
    [SerializeField] private BoxCollider2D normalCollider;
    [SerializeField] private CapsuleCollider2D duckCollider;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        normalCollider.enabled = true;
        duckCollider.enabled = false;
    }

   
    void Update()
    {
        isGrounded = CheckifGrounded();
        HandleJump();
        HandleDuck();
        HandleSoundEffect();
    }
    private bool CheckifGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }
    private void HandleDuck()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            normalCollider.enabled = false;
            duckCollider.enabled = true;
            animator.SetBool("isDuck", true);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            normalCollider.enabled = true;
            duckCollider.enabled = false;
            animator.SetBool("isDuck", false);
        }
    }
    private void HandleSoundEffect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.instance.PlayJumpClip();
        }
        if (isGrounded && !AudioManager.instance.hasPlayEffectSound())
        {
            AudioManager.instance.SetHasPlayEffectSound(true);
            AudioManager.instance.PlayTapClip();
        }
        else if (!isGrounded)
        {
            AudioManager.instance.SetHasPlayEffectSound(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            AudioManager.instance.PlayHurtClip();
        }
    }
}
