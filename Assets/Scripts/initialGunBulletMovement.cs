using UnityEngine;
using System.Collections;

public class initialGunBulletMovement : baseBullet {

	// Use this for initialization
	new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        bulletMovement();
	}
}
