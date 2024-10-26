using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAudioTrigger: MonoBehaviour
{
    public AK.Wwise.Event lightTrigger;
    private bool soundPlayed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Cat"
        if (collision.gameObject.CompareTag("Cat")&& !soundPlayed)
        {
            lightTrigger.Post(gameObject);
            soundPlayed = true;
        }
    }


}
