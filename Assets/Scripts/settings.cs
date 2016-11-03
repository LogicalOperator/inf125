using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class settings : MonoBehaviour {

    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Text masterVol;
    public Text musicVol;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void Start()
    {
        _UpdateAll();
    }
    public void _UpdateAll()
    {
        masterVol.text = masterVolumeSlider.value.ToString() + " %";
        musicVol.text = musicVolumeSlider.value.ToString() + " %";
    }

    public void OpenSettings()
    {
        if (mainMenu.activeSelf)
        {
            mainMenu.gameObject.SetActive(false);
            settingsMenu.gameObject.SetActive(true);
        }
        else
        {
            settingsMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }
}
