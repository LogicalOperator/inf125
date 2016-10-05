using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour {
    
    public void goToMenu()
    {
        SceneManager.LoadScene(0);//load scene 0(mainmenu)
    }
}
