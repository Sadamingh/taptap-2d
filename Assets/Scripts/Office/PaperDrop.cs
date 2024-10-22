using UnityEngine;

public class PaperDrop : MonoBehaviour
{
    public float fallSpeed = 1f;  // Speed at which the paper falls
    public float maxRotationSpeed = 50f;  // Maximum rotation speed for the paper
    public float sideToSideAmplitude = 1f;  // Amplitude of the side-to-side movement
    public float sideToSideFrequency = 1f;  // Frequency of the side-to-side movement

    private Vector3 startPosition;
    private float timeElapsed;
    private float randomInitialRotation;
    private float randomRotationSpeed;

    void Start()
    {
        // Store the initial position of the paper object
        startPosition = transform.position;
        timeElapsed = 0f;

        // Set a random initial rotation between -45 and 45 degrees
        randomInitialRotation = Random.Range(-45f, 45f);
        transform.Rotate(0f, 0f, randomInitialRotation);

        // Set a random rotation speed that will oscillate
        randomRotationSpeed = Random.Range(20f, maxRotationSpeed);
    }

    void Update()
    {
        // Update time
        timeElapsed += Time.deltaTime;

        // Apply vertical falling movement
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Apply side-to-side movement (simulate floating)
        float sideToSideMovement = Mathf.Sin(timeElapsed * sideToSideFrequency) * sideToSideAmplitude;
        transform.position = new Vector3(startPosition.x + sideToSideMovement, transform.position.y, transform.position.z);

        // Apply oscillating rotation to simulate paper rotation back and forth
        float rotationAngle = Mathf.Sin(timeElapsed * sideToSideFrequency) * randomRotationSpeed;
        transform.rotation = Quaternion.Euler(0f, 0f, randomInitialRotation + rotationAngle);
    }
}
