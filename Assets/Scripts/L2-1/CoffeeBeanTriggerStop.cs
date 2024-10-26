using UnityEngine;

public class CoffeeBeanTriggerStop : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject BeanInteractTrigger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we entered is named "BeanStop"
        if (other.gameObject.name == "BeanStop")
        {
            StopMovement();
        }
    }

    void StopMovement()
    {
        // Stop the coffee bean's movement by setting velocity to zero and disabling physics simulation
        rb.velocity = Vector2.zero;
        rb.simulated = false; // Freezes the coffee bean in its current position

        // Freeze rotation to stop any spinning effect
        rb.freezeRotation = true;

        BeanInteractTrigger.SetActive(true);
    }
}
