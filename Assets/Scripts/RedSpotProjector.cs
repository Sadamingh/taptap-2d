using UnityEngine;

public class RedSpotProjector : MonoBehaviour
{
    public GameObject redSpotPrefab;  // Reference to the red spot Quad prefab
    public Camera mainCamera;         // Reference to the main camera
    public GameObject cube;           // Reference to the cube object
    public float moveSpeed = 3f;      // Speed at which the cube will move

    private Vector3 targetPosition;   // Position to move the cube towards

    void Update()
    {
        // Cast a ray from the camera to the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a 3D object with a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Move the red spot decal to the point where the ray hits the surface
            redSpotPrefab.transform.position = hit.point;

            // Rotate the red spot so that it aligns with the surface normal
            redSpotPrefab.transform.rotation = Quaternion.LookRotation(hit.normal);

            // Adjust the red spot's orientation to align with the surface more accurately (rotate 90 degrees along X axis if needed)
            redSpotPrefab.transform.Rotate(90, 0, 0);

            // Update the target position for the cube to move towards
            targetPosition = hit.point;
        }

        // Move the cube smoothly towards the target position
        cube.transform.position = Vector3.Lerp(cube.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
