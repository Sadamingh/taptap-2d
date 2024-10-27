using UnityEngine;
using AK.Wwise; 

public class MainMenuMusicTrigger : MonoBehaviour
{
    public AK.Wwise.Event mainMenuMusicEvent;

    void Start()
    {
        mainMenuMusicEvent.Post(gameObject);
    }
}
