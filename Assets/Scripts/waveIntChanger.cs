using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveIntChanger : MonoBehaviour {
    //script used to change UI on canvas
    public Text wave;
	// Use this for initialization
	void Start () {
        wave = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        wave.text = "Wave Remaining: " + manager.waveRemaining;
	}
}
