using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            CatController cat = collision.GetComponent<CatController>();
            if (cat != null)
            {
                cat.TriggerFlashAndReset(); // Call the function to flash and reset the cat
            }
        }
    }
}
