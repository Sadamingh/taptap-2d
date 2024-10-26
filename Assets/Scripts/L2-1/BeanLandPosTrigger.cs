using UnityEngine;

public class BeanLandPosTrigger : MonoBehaviour
{
    public GameObject coffeeBean; // Assign the CoffeeBean object in the inspector
    public GameObject targetObject; // Assign the target object to show in the inspector
    public GameObject ratTalk;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "Cat"
        if (other.CompareTag("Cat"))
        {
            // Hide the coffee bean and show the target object
            if (coffeeBean != null)
            {
                coffeeBean.SetActive(false);
            }

            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }

            if (ratTalk != null)
            {
                ratTalk.SetActive(false);
            }
        }
    }
}
