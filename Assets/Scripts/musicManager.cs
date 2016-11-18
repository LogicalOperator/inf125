using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {

    public AudioClip mainTheme;
    public AudioClip menuTheme;

	// Use this for initialization
	void Start () {
        audioManager.instance.playMusic(menuTheme, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.instance.playMusic(mainTheme, 3f);
        }
	}
}
