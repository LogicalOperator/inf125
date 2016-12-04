using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cutSceneMethods : MonoBehaviour {
    public Image regularCity;
    public Image destroyedCity;

    public void setActive()
    {
        regularCity.gameObject.SetActive(false);
        destroyedCity.gameObject.SetActive(true);
    }

    public void goToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
