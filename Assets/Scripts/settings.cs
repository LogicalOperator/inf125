using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settings : MonoBehaviour {

    public Slider[] volumeSliders;
    public Text masterVol;
    public Text musicVol;
    public Text sfxVol;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public Toggle[] resolutionToggles;
    public int[] screenWidth;
    int activeScreenResolutionIndex;

    public void Start()
    {
        activeScreenResolutionIndex = PlayerPrefs.GetInt("screenResIndex");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;
        _UpdateAll();
        volumeSliders[0].value = audioManager.instance.masterVolumePercent;
        volumeSliders[1].value = audioManager.instance.musicVolumePercent;
        volumeSliders[2].value = audioManager.instance.sfxVolumePercent;

        if(resolutionToggles.Length == 0)
        {

        }
        else
        {
            for (int i = 0; i < resolutionToggles.Length; i++)
            {
                resolutionToggles[i].isOn = i == activeScreenResolutionIndex;
            }

            setFullScreen(isFullscreen);
        }

    }

    public void _UpdateAll() // update settings menu
    {
        masterVol.text = string.Format("{0:0%}", volumeSliders[0].value);
        musicVol.text = string.Format("{0:0%}", volumeSliders[1].value);
        sfxVol.text = string.Format("{0:0%}",volumeSliders[2].value);

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

    public void setScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResolutionIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidth[i], (int)(screenWidth[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screenResIndex", activeScreenResolutionIndex);
            PlayerPrefs.Save();
        }
    }



    public void setFullScreen(bool isFullScreen)
    {
        for(int i = 0; i<resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullScreen;
        }

        if (isFullScreen)
        {
            Resolution[] allResolution = Screen.resolutions;
            Resolution maxResolution = allResolution[allResolution.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            setScreenResolution(activeScreenResolutionIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullScreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void setAudioMaster (float value)
    {
        audioManager.instance.setVolume(value, audioManager.AudioChannel.master);
    }

    public void setAudioMusic(float value)
    {
        audioManager.instance.setVolume(value, audioManager.AudioChannel.music);
    }
    public void setAudioSfx(float value)
    {
        audioManager.instance.setVolume(value, audioManager.AudioChannel.sfx);
    }
    public void playGame()
    {
        SceneManager.LoadScene("Ground Floor");
    }

    public void onButtonHover()
    {

        audioManager.instance.playSound2D("hoverAudio");
    }

    public void onButtonClick()
    {
        audioManager.instance.playSound2D("onClickAudio");
    }

}
