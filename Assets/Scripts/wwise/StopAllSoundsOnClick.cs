using UnityEngine;

public class StopAllSoundsOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Stop all Wwise sounds when the object is clicked
        AkSoundEngine.StopAll();
        Debug.Log("All sounds stopped");
    }
}
