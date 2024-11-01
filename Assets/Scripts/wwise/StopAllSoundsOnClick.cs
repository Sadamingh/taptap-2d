using UnityEngine;

public class StopAllSoundsOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        //comment out the function so the music and the ambience keep playing

        // Stop all Wwise sounds when the object is clicked
        //AkSoundEngine.StopAll();
        //Debug.Log("All sounds stopped");
    }
}
