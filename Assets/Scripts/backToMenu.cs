using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour {
    
    public void goToMenu()
    {
        Time.timeScale = 1;
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("winCondition");
        SceneManager.LoadScene("Main Menu");//load scene 0(mainmenu)
    }
}
