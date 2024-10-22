using UnityEngine;

public class CatMoveNew : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;  // Higher jump force
    public float fallMultiplier = 3f;  // Stronger gravity when falling
    public float lowJumpMultiplier = 2.5f;  // Control height based on button press
    public Transform groundCheck;  // Ground check position (should be at the cat's feet)
    public float groundCheckRadius = 0.2f;  // Radius for the ground check
    public LayerMask groundLayer;  // Ground detection
    private Transform laserPointer;
    private SpriteRenderer laserSprite;
    private SpriteRenderer catSprite;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        // Find the laser object and get its SpriteRenderer component
        GameObject laserObject = GameObject.Find("Laser");
        if (laserObject != null)
        {
            laserPointer = laserObject.transform;
            laserSprite = laserObject.GetComponent<SpriteRenderer>();
        }

        // Get the SpriteRenderer component of the cat
        catSprite = GetComponent<SpriteRenderer>();

        // Get the Rigidbody2D component for the cat's physics
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the cat is grounded by using the groundCheck position and radius
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Apply custom gravity to make falling quicker
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))  // Let go of the jump button
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Check if the laser exists and if its sprite is enabled before moving the cat
        if (laserPointer != null && laserSprite.enabled)
        {
            // Move the cat toward the laser's position
            transform.position = Vector2.MoveTowards(transform.position, laserPointer.position, speed * Time.deltaTime);

            // Flip the cat sprite based on the direction of the laser pointer
            if (laserPointer.position.x < transform.position.x)
            {
                catSprite.flipX = true;
            }
            else if (laserPointer.position.x > transform.position.x)
            {
                catSprite.flipX = false;
            }

            // Check if the laser pointer is above the cat and the cat is grounded before jumping
            if (laserPointer.position.y > transform.position.y && isGrounded)
            {
                // Directly set the velocity to make the cat jump with more control
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    // Visualize the ground check radius in the Scene view for debugging
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
