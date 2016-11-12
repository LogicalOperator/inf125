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
    public void _UpdateAll() // update settings menu
    {
        masterVol.text = masterVolumeSlider.value + " %";
        musicVol.text = musicVolumeSlider.value + " %";
    }

    public void OpenSettings() //toggle main menu/settings menus
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

    public void saveAllSettings() // save settings for main game
    {
        PlayerPrefs.SetFloat("masterVol", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("music", musicVolumeSlider.value);
    }
}
