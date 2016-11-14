using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goldChanger : MonoBehaviour {
    Text goldText;
    public static int gold;

	// Use this for initialization
	void Start () {
        goldText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        goldText.text = "Gold: " + gold;
	}
}
