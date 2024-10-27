using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueControl dialogueControl; // Reference to the DialogueControl script
    public CatMove catMove;
    public CatMoveNew catMoveNew;
    public GameObject laserObject;
    private LaserPointer laserPointer;

    private bool hasTriggered = false; // Ensures trigger can only activate once

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Cat"))
        {
            hasTriggered = true; // Set to true immediately to prevent further triggers
            Debug.Log("Cat comes");
            dialogueControl.isDiaTriggered = true;

            StartCoroutine(DisableAfterDelay(0.5f)); // Start coroutine with 0.5s delay
        }
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        if (catMove != null)
        {
            catMove.enabled = false;
        } 
        else if (catMoveNew != null)
        {
            catMoveNew.enabled = false;
        }

        if (laserObject != null)
        {
            laserPointer = laserObject.GetComponent<LaserPointer>();
            laserObject.SetActive(false); // Hide the laser object initially
            if (laserPointer != null)
            {
                laserPointer.enabled = false;
            }
        }

        Debug.Log("catMove and laser disabled after delay");
    }
}
