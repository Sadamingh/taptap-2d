using System.Collections;
using UnityEngine;

public class FeetMovement : MonoBehaviour
{
    public float moveDistance = 1f;     // Distance the feet will move down
    public float shakeAmount = 0.05f;   // Amount of shaking before moving down
    public float downSpeed = 5f;        // Initial speed for moving down
    public float upSpeed = 10f;         // Speed for moving up
    public float groundHoldMin = 1f;    // Minimum time to hold on the ground
    public float groundHoldMax = 2f;    // Maximum time to hold on the ground
    public float shakeMin = 1f;         // Minimum shake time
    public float shakeMax = 2f;         // Maximum shake time
    public float topHoldMin = 1f;       // Minimum hold time at the top before shaking
    public float topHoldMax = 3f;       // Maximum hold time at the top before shaking

    private Vector3 originalPosition;   // Original position of the feet
    private bool isShaking = false;

    private void Start()
    {
        originalPosition = transform.position; // Store the original position of the feet
        StartCoroutine(FeetMovementCycle());   // Start the movement cycle
    }

    // Coroutine to handle the entire feet movement cycle
    private IEnumerator FeetMovementCycle()
    {
        while (true)
        {
            // Step 1: Hold at the top for 1-3 seconds randomly
            yield return StartCoroutine(HoldAtTop());

            // Step 2: Shake for 1-2 seconds randomly
            yield return StartCoroutine(ShakeFeet());

            // Step 3: Move down with acceleration
            yield return StartCoroutine(MoveDown());

            // Step 4: Hold on the ground for 1-2 seconds randomly
            yield return new WaitForSeconds(Random.Range(groundHoldMin, groundHoldMax));

            // Step 5: Move up quickly and reset position
            yield return StartCoroutine(MoveUp());
        }
    }

    // Coroutine to handle holding at the top for 1-3 seconds randomly
    private IEnumerator HoldAtTop()
    {
        float holdTime = Random.Range(topHoldMin, topHoldMax); // Random hold time
        yield return new WaitForSeconds(holdTime); // Wait at the top for the hold time
    }

    // Coroutine to handle shaking before moving down
    private IEnumerator ShakeFeet()
    {
        isShaking = true;
        float shakeTime = Random.Range(shakeMin, shakeMax); // Random shake time
        float elapsedTime = 0f;

        while (elapsedTime < shakeTime)
        {
            // Shake the feet by moving it slightly left and right
            transform.position = originalPosition + new Vector3(Random.Range(-shakeAmount, shakeAmount), 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the position after shaking
        transform.position = originalPosition;
        isShaking = false;
    }

    // Coroutine to handle moving down with acceleration
    private IEnumerator MoveDown()
    {
        float currentSpeed = 0f; // Start at 0 speed and accelerate
        Vector3 targetPosition = originalPosition - new Vector3(0, moveDistance, 0);
        float timeToReachTarget = moveDistance / downSpeed; // Time calculated by distance/speed

        while (transform.position.y > targetPosition.y)
        {
            // Accelerate down
            currentSpeed += downSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure it's exactly at the target position
        transform.position = targetPosition;
    }

    // Coroutine to handle moving up quickly and resetting position
    private IEnumerator MoveUp()
    {
        Vector3 targetPosition = originalPosition;

        // Fast move up
        while (transform.position.y < targetPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, upSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure the position is reset to the original
        transform.position = targetPosition;
    }
}
