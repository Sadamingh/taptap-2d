using UnityEngine;

public class CameraFollowOffice : MonoBehaviour
{
    public Transform catTransform;  // Reference to the cat's transform
    private Vector3 initialCameraPosition;  // Initial camera position
    private float minY;  // Minimum Y position that the camera can move to

    void Start()
    {
        // Store the initial position of the camera
        initialCameraPosition = transform.position;
        // Set the minimum Y to the initial Y position of the camera
        minY = initialCameraPosition.y;
    }

    void LateUpdate()
    {
        if (catTransform != null)
        {
            // Get the camera's current position
            Vector3 cameraPosition = transform.position;

            // Follow the cat's Y position but ensure the camera doesn't go below the initial Y
            cameraPosition.y = Mathf.Max(catTransform.position.y, minY);

            // Apply the new camera position
            transform.position = cameraPosition;
        }
    }
}
