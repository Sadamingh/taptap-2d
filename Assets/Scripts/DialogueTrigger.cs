using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueControl dialogueControl; // Reference to the DialogueControl script
    public CatMove catMove;
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

            if (catMove != null)
            {
                catMove.enabled = false;
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
        }
    }
}
