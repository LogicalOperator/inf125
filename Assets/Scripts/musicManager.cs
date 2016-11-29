using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{

    public AudioClip mainTheme;
    public AudioClip menuTheme;
    string sceneName;
    // Use this for initialization
    void Start()
    {
        OnLevelWasLoaded(1);
    }

    void OnLevelWasLoaded(int sceneIndex)
    {
        string newSceneName = SceneManager.GetActiveScene().name;
        if (newSceneName != sceneName)
        {
            sceneName = newSceneName;
            Invoke("PlayMusic", .2f);
        }

    }

    void PlayMusic()
    {
        AudioClip clipToPlay = null;

        if (sceneName == "Main Menu")
        {
            clipToPlay = menuTheme;
        }
        else if (sceneName == "mainGame")
        {
            clipToPlay = mainTheme;
        }

        if (clipToPlay != null)
        {
            audioManager.instance.playMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }
    }

}
