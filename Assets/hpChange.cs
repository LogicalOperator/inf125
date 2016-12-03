using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpChange : MonoBehaviour {
    Transform hpBarT;
    Image hpBar;
	// Use this for initialization
	void Start () {
        hpBarT = GetComponent<Transform>();
        hpBar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hpBarT.localScale.x > 0.7)
        {
            hpBar.color = Color.green;
        }
        else if (hpBarT.localScale.x <= 0.7 && hpBarT.localScale.x > 0.4)
        {
            hpBar.color = Color.yellow;
        }
        else
        {
            hpBar.color = Color.red;
        }
	}
}
