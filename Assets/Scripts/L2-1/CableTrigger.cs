using UnityEngine;

public class CableTrigger : MonoBehaviour
{
    public GameObject cableObject; // Reference to the cable object
    public Sprite tightSprite; // Sprite for the tight cable
    public GameObject coffeeBean; // Reference to the CoffeeBean object in the scene

    private SpriteRenderer cableSpriteRenderer;
    private Rigidbody2D coffeeBeanRb;
    private Vector3 initialCoffeeBeanPosition;
    private bool hasLaunched = false; // Flag to ensure coffee bean launches only once

    void Start()
    {
        if (cableObject != null)
        {
            cableSpriteRenderer = cableObject.GetComponent<SpriteRenderer>();
        }

        // Ensure the coffee bean is initially hidden and get its Rigidbody2D
        if (coffeeBean != null)
        {
            coffeeBean.SetActive(false);
            coffeeBeanRb = coffeeBean.GetComponent<Rigidbody2D>();
            initialCoffeeBeanPosition = coffeeBean.transform.position;

            // Add Rigidbody2D if not present
            if (coffeeBeanRb == null)
            {
                coffeeBeanRb = coffeeBean.AddComponent<Rigidbody2D>();
            }
            coffeeBeanRb.gravityScale = 1; // Enable gravity for parabolic movement
            coffeeBeanRb.simulated = false; // Disable physics until needed
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "Cat" and the coffee bean hasn't launched
        if (other.CompareTag("Cat") && cableSpriteRenderer != null && !hasLaunched)
        {
            cableSpriteRenderer.sprite = tightSprite; // Change the cable's sprite to tight
            ShowAndLaunchCoffeeBean(); // Show and launch the coffee bean
            hasLaunched = true; // Set the flag to true to prevent re-triggering
        }
    }

    void ShowAndLaunchCoffeeBean()
    {
        // Reset the coffee bean to its initial position, activate it, and set velocity
        coffeeBean.transform.position = initialCoffeeBeanPosition;
        coffeeBean.SetActive(true);

        // Simulate physics and apply an initial parabolic force
        coffeeBeanRb.simulated = true;
        float launchSpeed = 7f; // Adjust this value to control the launch speed
        Vector2 launchDirection = new Vector2(1, 3).normalized; // Launch to the right and upwards
        coffeeBeanRb.velocity = launchDirection * launchSpeed;

        // Start rotation on the coffee bean
        coffeeBean.AddComponent<CoffeeBeanRotation>(); // Ensures it rotates
    }
}

// This additional script handles the rotation of the CoffeeBean object
public class CoffeeBeanRotation : MonoBehaviour
{
    public float rotationSpeed = 400f; // Speed of rotation

    void Update()
    {
        // Rotate the coffee bean around its Z-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
