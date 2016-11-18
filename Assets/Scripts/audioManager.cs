using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour
{

    public enum AudioChannel { master, sfx, music };
    public float masterVolumePercent { get; private set; }
    public float musicVolumePercent { get; private set; }
    public float sfxVolumePercent { get; private set; }
    int activeMusicSourceIndex;
    AudioSource sfx2DSource;
    AudioSource[] musicSources;
    public static audioManager instance;
    soundLibrary library;
    Transform playerT;
    Transform audioListener;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            library = GetComponent<soundLibrary>();
            instance = this;
            musicSources = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newMusicSource = new GameObject("Music Source " + (i + 1));
                musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                newMusicSource.transform.parent = transform;
            }
        }
        GameObject newSfx2DSource = new GameObject("2DSfxSource");
        sfx2DSource = newSfx2DSource.AddComponent<AudioSource>();
        newSfx2DSource.transform.parent = transform;



        
        audioListener = FindObjectOfType<AudioListener>().transform;
        if(FindObjectOfType<controller>() != null)
        {
            playerT = FindObjectOfType<controller>().transform;
        }

        masterVolumePercent = PlayerPrefs.GetFloat("masterVol", 1);
        musicVolumePercent = PlayerPrefs.GetFloat("music", 1);
        sfxVolumePercent = PlayerPrefs.GetFloat("sfx", 1);

    }

    void Update()
    {
        if(playerT != null)
        {
            audioListener.position = playerT.position;
        }
    }

    public void setVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChannel.sfx:
                sfxVolumePercent = volumePercent;
                break;
            case AudioChannel.music:
                musicVolumePercent = volumePercent;
                break;
        }
        musicSources[0].volume = musicVolumePercent * masterVolumePercent;
        musicSources[1].volume = musicVolumePercent * masterVolumePercent;

        PlayerPrefs.SetFloat("masterVol", masterVolumePercent);
        PlayerPrefs.SetFloat("music", musicVolumePercent);
        PlayerPrefs.SetFloat("sfx", sfxVolumePercent);
        PlayerPrefs.Save();

    }


    public void playMusic(AudioClip clip, float fadeDuration = 1)
    {
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;
        musicSources[activeMusicSourceIndex].clip = clip;
        musicSources[activeMusicSourceIndex].Play();

        StartCoroutine(animateMusicCrossFade(fadeDuration));

    }
    public void playSound(AudioClip audio, Vector3 pos)
    {
        if (audio != null)
        {
            AudioSource.PlayClipAtPoint(audio, pos, sfxVolumePercent * masterVolumePercent);
            
        }
    }

    public void playSound(string audioName, Vector3 pos)
    {
        playSound(library.getClipFromName(audioName), pos);
    }

    public void playSound2D(string soundName) {
        sfx2DSource.PlayOneShot(library.getClipFromName(soundName), sfxVolumePercent * masterVolumePercent);
    }
        

    IEnumerator animateMusicCrossFade(float duration)
    {
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSources[activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            musicSources[1 - activeMusicSourceIndex].volume = Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            yield return null;
        }
    }
}
