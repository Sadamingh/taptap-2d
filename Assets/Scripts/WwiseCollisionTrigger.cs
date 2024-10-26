using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseCollisionTrigger : MonoBehaviour

{
    //select wwise event
    public AK.Wwise.Event lightTrigger;
    //sound check to make sure the sound doesn't trigger twice
    private bool soundPlayed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with has the tag "Cat"
        if (collision.gameObject.CompareTag("Cat") && !soundPlayed)
        {
            //trigger the wwise audio event
            lightTrigger.Post(gameObject);
            //set the sound check to true to prevent repetitive trigger
            soundPlayed = true;
        }
    }


}