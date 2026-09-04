using UnityEngine;


public class DinoScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public LogicScript logic;
    public float jumpForce = 12f; // Increased slightly for a snappier launch

    // Snappy jump multipliers
    public float fallMultiplier = 4f;       // How fast you snap back to the ground
    public float lowJumpMultiplier = 3f;   // Allows short hops if you tap space quickly

    private bool isGrounded = false;

    void Update()
    {
        // 1. Regular Jump Logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // 2. Snappy Physics Modifiers (The Magic Juice)
        if (rb.linearVelocity.y < 0)
        {
            // If the Dino is falling downward, apply heavier gravity
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // If the Dino is rising but the player let go of Space early, cut the jump short
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            logic.GameOver();
        }
    }
}
