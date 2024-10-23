using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    private void OnMouseDown()
    {
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
