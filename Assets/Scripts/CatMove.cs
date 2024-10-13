using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float speed = 5f;
    public float maxJumpForce = 10f;  // Maximum jump force
    public float minJumpForce = 2f;   // Minimum jump force
    private Transform laserPointer;
    private SpriteRenderer laserSprite;
    private SpriteRenderer catSprite;
    private Rigidbody2D rb;

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
        // Check if the laser exists and if its sprite is enabled before moving the cat
        if (laserPointer != null && laserSprite.enabled)
        {
            // Move the cat toward the laser's position
            transform.position = Vector2.MoveTowards(transform.position, laserPointer.position, speed * Time.deltaTime);

            // Flip the cat sprite based on the direction of the laser pointer
            if (laserPointer.position.x < transform.position.x)
            {
                // Laser is to the left, flip the sprite
                catSprite.flipX = true;
            }
            else if (laserPointer.position.x > transform.position.x)
            {
                // Laser is to the right, don't flip the sprite
                catSprite.flipX = false;
            }

            // Check if the laser pointer is above the cat
            if (laserPointer.position.y > transform.position.y)
            {
                // Calculate the vertical distance between the laser and the cat
                float distance = laserPointer.position.y - transform.position.y;

                // Calculate a proportional jump force based on the distance
                float jumpForce = Mathf.Clamp(distance, minJumpForce, maxJumpForce);

                // Apply an upward force to make the cat jump, based on the distance
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
