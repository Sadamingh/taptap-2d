using System.Collections;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer for flashing
    public float flashDuration = 0.1f;    // Time for each flash
    public int flashCount = 5;            // Number of times the sprite flashes
    private Vector3 originalPosition;     // Store the original position of the cat

    private void Start()
    {
        originalPosition = transform.position; // Store the initial position of the cat
    }

    public void TriggerFlashAndReset()
    {
        StartCoroutine(FlashAndReset()); // Start a coroutine to handle flashing and resetting
    }

    private IEnumerator FlashAndReset()
    {
        yield return StartCoroutine(FlashSprite()); // Start flashing
        yield return new WaitForSeconds(0.05f);     // Wait for 0.15 seconds after flashing
        ResetPosition();                            // Then reset the position
    }

    // Coroutine to handle flashing effect
    private IEnumerator FlashSprite()
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    // Function to reset the cat's position
    private void ResetPosition()
    {
        transform.position = originalPosition;
    }
}
