using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Make sure to include this

public class ButtonCtrl : MonoBehaviour
{
    public void RestartLevel()
    {
        // Get the active scene and reload it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Cursor.visible = false;
    }

    // Function to load scene 0
    public void GoToScene0()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    // Function to load scene 1
    public void GoToScene1()
    {
        SceneManager.LoadScene(1);
    }

    // Function to load scene 2
    public void GoToScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToScene3()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToScene4()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToScene5()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToScene6()
    {
        SceneManager.LoadScene(6);
    }

    public void GoToScene7()
    {
        SceneManager.LoadScene(7);
    }

    public void GoToScene8()
    {
        SceneManager.LoadScene(8);
    }
}
