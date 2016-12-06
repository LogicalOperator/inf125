using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour {
	public audioManager audio;
	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("winCondition");
        PlayerPrefs.DeleteKey("primaryGunIndex");
        PlayerPrefs.DeleteKey("secondaryGunIndex");
		
		 StartCoroutine(timerCutscene());
    }
	
	IEnumerator  timerCutscene(){
		yield return new WaitForSeconds(120);
		Destroy(audio.gameObject);
		SceneManager.LoadScene("cutScene");
	}
    
}
