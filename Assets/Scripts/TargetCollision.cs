using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public DialogueControl dialogueControl; // Reference to the DialogueControl script

    // This method will be triggered when another object with a Collider2D enters the trigger zone
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Cat"
        if (collision.gameObject.CompareTag("Cat"))
        {
            // Start the dialogue when the Cat enters the trigger zone
            dialogueControl.DisplayNextDialogue();

            // Make the cursor visible (as per your requirement)
            Cursor.visible = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Cat"
        if (collision.gameObject.CompareTag("Cat"))
        {
            dialogueControl.currentDialogueIndex = 0;
            dialogueControl.EndDialogue();
        }
    }
}
