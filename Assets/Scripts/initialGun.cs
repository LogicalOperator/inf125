using UnityEngine;
using System.Collections;

public class initialGun : baseGunScript {

	// Use this for initialization
	void Start () {
        gunName = "Pistol"; //update gunname, dmg mod, and other things here
	}
	
	// Update is called once per frame
	void Update () {
        summonBullet();
	}
}
