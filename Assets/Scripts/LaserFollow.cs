using UnityEngine;

public class LaserFollow : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in the world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the z position to 0 so the laser stays on the 2D plane
        mousePosition.z = 0f;

        // Set the laser's position to the mouse position
        transform.position = mousePosition;
    }
}
