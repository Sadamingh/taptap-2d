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
}
