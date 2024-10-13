using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public GameObject successPanel; // Drag your Success Panel here in the Inspector

    void Start()
    {
        // Ensure the success panel is initially disabled
        successPanel.SetActive(false);
    }

    // This method will be triggered when another object with a Collider2D enters the trigger zone
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Cat"
        if (collision.gameObject.CompareTag("Cat"))
        {
            // Enable the success panel in the UI
            successPanel.SetActive(true);
            
            Cursor.visible = true;
        }
    }
}
