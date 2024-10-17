using UnityEngine;

public class CatCollisionHandler : MonoBehaviour
{
    // Public SpriteRenderer to be modified
    public SpriteRenderer bgSprite;

    // Internal flag to check if the object is flipped
    private bool isFlipped = false;

    // Method called when a collision happens
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            // Change the sprite color to white
            if (bgSprite != null)
            {
                bgSprite.color = Color.white;
            }

            // Flip the object by 180 degrees
            if (!isFlipped)
            {
                // Flipping along the Y
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
                isFlipped = true;
            }
        }
    }
}
