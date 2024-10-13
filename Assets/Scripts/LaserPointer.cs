using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private SpriteRenderer laserSprite;

    void Start()
    {
        // Get the SpriteRenderer component attached to the laser object
        laserSprite = GetComponent<SpriteRenderer>();

        // Initially disable the laser (make it invisible)
        laserSprite.enabled = false;
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Enable the laser (make it visible)
            laserSprite.enabled = true;
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Disable the laser (make it invisible)
            laserSprite.enabled = false;
        }
    }
}
