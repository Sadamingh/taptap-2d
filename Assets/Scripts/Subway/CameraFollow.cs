using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector2 offset;   // Offset to apply after the character is centered
    public float smoothSpeed = 0.125f;

    private bool followPlayer = false;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
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
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
