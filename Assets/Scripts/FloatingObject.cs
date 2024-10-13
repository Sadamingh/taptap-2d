using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatSpeed = 1f;     // Speed of the floating motion
    public float floatAmplitude = 0.5f; // Amplitude of the floating motion (how far it moves up and down)
    private Vector3 startPosition;

    void Start()
    {
        // Store the object's initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Apply a floating effect using a sine wave for smooth movement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
