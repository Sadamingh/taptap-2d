using UnityEngine;

public class EyesLookAtMouse : MonoBehaviour
{
    public Transform leftEye;     // Reference to the left eye object
    public Transform rightEye;    // Reference to the right eye object
    public float eyeMoveRange = 0.1f; // Maximum range each eye can move from its original position

    private Vector3 leftEyeOriginalPos;
    private Vector3 rightEyeOriginalPos;

    void Start()
    {
        // Store each eye's initial local position
        leftEyeOriginalPos = leftEye.localPosition;
        rightEyeOriginalPos = rightEye.localPosition;
    }

    void Update()
    {
        // Get mouse position in world space and convert it to UI space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Keep Z at 0 for 2D UI

        // Move each eye toward the mouse within the limited range
        MoveEyeTowards(leftEye, leftEyeOriginalPos, mousePosition);
        MoveEyeTowards(rightEye, rightEyeOriginalPos, mousePosition);
    }

    void MoveEyeTowards(Transform eye, Vector3 originalPos, Vector3 targetPosition)
    {
        // Calculate the direction from the eye to the target (mouse)
        Vector3 direction = (targetPosition - eye.position).normalized;

        // Calculate the target position within the allowed range
        Vector3 targetPos = originalPos + direction * eyeMoveRange;

        // Set the eye's position within the range
        eye.localPosition = Vector3.Lerp(eye.localPosition, targetPos, 0.1f); // Smooth movement toward target position
    }
}
