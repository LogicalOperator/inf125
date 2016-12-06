using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeManager : MonoBehaviour {

    private Image fadingImage;
	// Use this for initialization
	void Awake () {
        fadingImage = GetComponent<Image>();
        fadingImage.CrossFadeAlpha(0, 2.5f, false);
	}
}
