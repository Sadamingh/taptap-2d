using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector2 offset;   // Offset to apply after the character is centered
    public float smoothSpeed = 0.125f;
    public float minX; // Minimum X limit for the camera
    public float maxX; // Maximum X limit for the camera

    private bool followPlayer = false;
    private Camera cam;
    private float initialYPosition;

    void Start()
    {
        cam = Camera.main;
        initialYPosition = transform.position.y; // Store the initial Y position of the camera
    }

    void Update()
    {
        // Convert player's position to viewport coordinates (0 to 1 range)
        Vector3 playerViewportPos = cam.WorldToViewportPoint(target.position);

        // Check if the player has reached the middle of the screen (approximately)
        if (playerViewportPos.x >= 0.5f && !followPlayer)
        {
            followPlayer = true; // Start following the player when they reach the center
        }
    }

    void LateUpdate()
    {
        if (followPlayer)
        {
            // Calculate the desired position on X-axis only, keeping Y fixed
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, initialYPosition, transform.position.z);
            
            // Apply horizontal limits to keep the camera within the range
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);

            // Smoothly transition the camera position with clamped X
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, initialYPosition, desiredPosition.z), smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
