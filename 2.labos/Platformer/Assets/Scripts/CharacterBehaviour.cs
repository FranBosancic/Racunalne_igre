using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    private float moveInput;
    private bool isGrounded;

    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // samo se gleda input  tu
    void Update()
    {
        
        moveInput = Input.GetAxisRaw("Horizontal");

        // Animacije i smjer
        animator.SetBool("isRunning", moveInput != 0);
        spriteRenderer.flipX = moveInput < 0;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    // Tu se mora fizicki mijenjat 
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetBool("isJumping", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.CompareTag("FallenOffTag") ||
            collision.gameObject.CompareTag("SpikeTag") ||
            collision.gameObject.CompareTag("EndTag"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
