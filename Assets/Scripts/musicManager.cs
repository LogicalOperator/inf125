using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{

    public AudioClip mainTheme;
    public AudioClip menuTheme;
    public AudioClip hallwayTheme;
    public AudioClip darknessTheme;
    public AudioClip creditsTheme;
    public AudioClip gameOverTheme;
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
        else if (sceneName == "Ground Floor")
        {
            clipToPlay = mainTheme;
        }
        else if(sceneName == "Credits")
        {
            clipToPlay = creditsTheme;
        }
        else if (sceneName == "gameOver")
        {
            clipToPlay = creditsTheme;
        }
        else
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
