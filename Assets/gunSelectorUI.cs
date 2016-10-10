using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gunSelectorUI : MonoBehaviour {
    public Image gunImage;
	// Use this for initialization
	void Awake () {
        gunImage = GetComponent<Image>();
	}

    public void UpdateGunImage(Sprite currentGunImage)
    {
        gunImage.sprite = currentGunImage;
    }
}
