using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    // Speed of the object movement
    public float speed = 5f;
    // Distance it will move to the right and then back
    public float distance = 3f;

    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        // Store the starting position in 2D
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the movement
        if (movingRight)
        {
            // Move the object to the right
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

            // Check if it has moved the required distance
            if (transform.position.x >= startPos.x + distance)
            {
                movingRight = false; // Change direction
            }
        }
        else
        {
            // Move the object to the left
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

            // Check if it has returned to the starting point
            if (transform.position.x <= startPos.x - distance)
            {
                movingRight = true; // Change direction
            }
        }
    }
}
