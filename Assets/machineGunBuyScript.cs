using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class machineGunBuyScript : buyableBase {

	// Use this for initialization
	void Start () {
        gunIndex = 3;
        gunType = "dark";
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
        this.transform.GetChild(0).GetComponent<Text>().text = " "+goldCost;

    }
	
}
