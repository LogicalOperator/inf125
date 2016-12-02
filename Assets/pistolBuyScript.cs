using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pistolBuyScript : buyableBase {

	// Use this for initialization
	void Start () {
        gunIndex = 2;
        goldCost = 30;
        gunType = "light";
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
        this.transform.GetChild(0).GetComponent<Text>().text = " " + goldCost;
    }

}
