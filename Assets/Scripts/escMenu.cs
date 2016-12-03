using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class escMenu : MonoBehaviour
{
    public GameObject soundOptions;

    public void goToMenu()
    {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("winCondition");
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");//load scene 1(mainmenu)
    }

    public void openOptions()
    {
        if (soundOptions.gameObject.activeSelf)
        {
            
            soundOptions.gameObject.SetActive(false);
        }
        else
        {
            soundOptions.gameObject.SetActive(true);
        }
    }
}
