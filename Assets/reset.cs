using UnityEngine;
using System.Collections;

public class reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("winCondition");
        PlayerPrefs.DeleteKey("primaryGunIndex");
        PlayerPrefs.DeleteKey("secondaryGunIndex");
    }
    
}
