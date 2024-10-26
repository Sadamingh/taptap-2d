using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public Image[] cgs; // Drag your CG images here
    public float fadeDuration = 1f;
    public float displayDuration = 2f;

    private int currentCG = 0;

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        foreach (Image cg in cgs)
        {
            // Set the initial alpha of the image to 0 (invisible)
            cg.canvasRenderer.SetAlpha(0f);
            cg.gameObject.SetActive(true);
            
            // Fade in
            cg.CrossFadeAlpha(1f, fadeDuration, false);
            yield return new WaitForSeconds(fadeDuration + displayDuration);
            
            // Fade out
            cg.CrossFadeAlpha(0f, fadeDuration, false);
            yield return new WaitForSeconds(fadeDuration);
            
            cg.gameObject.SetActive(false);
        }
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
