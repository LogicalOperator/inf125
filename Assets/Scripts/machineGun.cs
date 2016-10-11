using UnityEngine;
using System.Collections;

public class machineGun : baseGunScript {

	// Use this for initialization
	void Start () {
        gunName = "Machine Gun";
        fireRate = 0.3f;
        dmgMod = -5;
	}
	
	// Update is called once per frame
	void Update () {
        summonBullet();
	}

}
