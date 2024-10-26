using UnityEngine;
using System.Collections;

public class StaffMovement : MonoBehaviour
{
    public Sprite backSprite; // Sprite when facing back
    public Sprite frontSprite; // Sprite when facing front
    public float moveAmount = 0.5f; // Distance to move up and down
    public float moveSpeed = 1f; // Speed of up and down movement
    public float switchTime = 2f; // Time in seconds before switching sprites

    private SpriteRenderer spriteRenderer;
    private Vector3 initialPosition;
    private bool isMovingUpDown = true;
    private float timer;
    public CatCoverageChecker catCoverageChecker; // Reference to CatCoverageChecker

    private Coroutine coverageCheckCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backSprite;
        initialPosition = transform.position;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isMovingUpDown)
        {
            // Move the staff up and down
            float yOffset = Mathf.Sin(timer * moveSpeed) * moveAmount;
            transform.position = initialPosition + new Vector3(0, yOffset, 0);

            // Switch sprite after the designated time
            if (timer >= switchTime)
            {
                isMovingUpDown = false;
                spriteRenderer.sprite = frontSprite; // Switch to front-facing sprite
                StartCoverageCheck(); // Start repeated coverage check
                timer = 0; // Reset timer for next phase
            }
        }
        else
        {
            // Keep staff at the initial position with the front sprite for `switchTime` seconds
            transform.position = initialPosition;

            if (timer >= switchTime)
            {
                isMovingUpDown = true;
                spriteRenderer.sprite = backSprite; // Switch back to back-facing sprite
                StopCoverageCheck(); // Stop repeated coverage check
                timer = 0; // Reset timer for next phase
            }
        }
    }

    private void StartCoverageCheck()
    {
        if (coverageCheckCoroutine == null)
        {
            coverageCheckCoroutine = StartCoroutine(CoverageCheckRoutine());
        }
    }

    private void StopCoverageCheck()
    {
        if (coverageCheckCoroutine != null)
        {
            StopCoroutine(coverageCheckCoroutine);
            coverageCheckCoroutine = null;
        }
    }

    private IEnumerator CoverageCheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); // Check every 0.1 seconds

            if (!catCoverageChecker.IsFullyCovered())
            {
                catCoverageChecker.catController.TriggerFlashAndReset();
                StopCoverageCheck(); // Stop checking once triggered
            }
        }
    }
}
