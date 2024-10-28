using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueControl dialogueControl; // Reference to the DialogueControl script
    public CatMove catMove;
    public CatMoveNew catMoveNew;
    public GameObject laserObject;
    private LaserPointer laserPointer;

    public bool needFlip = false; // Flag to determine if the Cat sprite should be flipped
    private bool hasTriggered = false; // Ensures trigger can only activate once

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Cat"))
        {
            hasTriggered = true; // Set to true immediately to prevent further triggers
            Debug.Log("Cat comes");
            dialogueControl.isDiaTriggered = true;

            StartCoroutine(DisableAfterDelay(0.5f, other.gameObject)); // Pass Cat object to coroutine
        }
    }

    private IEnumerator DisableAfterDelay(float delay, GameObject catObject)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Disable cat movement scripts if they exist
        if (catMove != null)
        {
            catMove.enabled = false;
        } 
        else if (catMoveNew != null)
        {
            catMoveNew.enabled = false;
        }

        // Disable laser pointer if it exists
        if (laserObject != null)
        {
            laserPointer = laserObject.GetComponent<LaserPointer>();
            laserObject.SetActive(false); // Hide the laser object initially
            if (laserPointer != null)
            {
                laserPointer.enabled = false;
            }
        }

        // Flip the sprite of the Cat object if needFlip is true
        if (needFlip)
        {
            SpriteRenderer spriteRenderer = catObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX; // Toggle the horizontal flip of the sprite
            }
        }

        Debug.Log("catMove and laser disabled, and sprite flipped if needed, after delay");
    }
}
