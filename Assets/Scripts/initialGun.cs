using UnityEngine;
using System.Collections;

public class initialGun : baseGunScript {

    // Use this for initialization
    void Start () {
        gunName = "Pistol"; //update gunname, dmg mod, firing rate and other things here
        fireRate = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
        summonBullet();
	}
}
