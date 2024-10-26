using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public AK.Wwise.Event wwiseEventName;  // Wwise Event Name
    private void OnMouseDown()
    {
        //play sfx entering next level
        wwiseEventName.Post(gameObject);

        // Load the next scene when the object is clicked
        LoadNextScene();
    }

    void LoadNextScene()
    {
        // Get the current active scene's index and load the next scene in the build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
