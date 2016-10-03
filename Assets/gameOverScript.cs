using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        score.text = "Score: " + scoreChanger.scoreint;
	}

}
