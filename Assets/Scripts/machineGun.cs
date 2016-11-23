using UnityEngine;
using System.Collections;

public class machineGun : baseGunScript {

	// Use this for initialization
	void Awake () {
        gunName = "Machine Gun";
        fireRate = 0.3f;
        dmgMod = -5;
        gunType = "dark";
        gunTypeValue = 2.8f;
        player = GameObject.FindGameObjectWithTag("Player");
        libraryIndex = 1;
    }
	
	// Update is called once per frame
	void Update () {
        summonBullet();
        specialFire();
	}

	public override void specialFire()//speical fire for max resource
	{

		Vector3 pos = new Vector3();
		Vector3 rotation_to = new Vector3();

		if (Input.GetMouseButton(1) || (Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)))) {
			if (player.GetComponent<controller>().currentDark < 100)//check if max light, if not play not full sound
			{
				audioManager.instance.playSound(emptyGunSound, transform.position);
			}
			else
			{
				if (Input.GetMouseButton (1)) {
					pos = Input.mousePosition; // obtain mousepostion
					pos = Camera.main.ScreenToWorldPoint (pos); // obtain exact mouse position from main camera screen
					pos.z = transform.position.z;

					rotation_to = pos - transform.position;
				}
				else {
					if (Input.GetKey (KeyCode.J)) {
						rotation_to = Vector3.left;
					} 
					if (Input.GetKey (KeyCode.L)) {
						rotation_to += Vector3.right;
					} 
					if (Input.GetKey (KeyCode.I)) {
						rotation_to += Vector3.up;
					}
					if (Input.GetKey (KeyCode.K)) {
						rotation_to += Vector3.down;
					}
				}

				player.GetComponent<controller>().resetBars(); //reset both resources
				audioManager.instance.playSound(gunSound, transform.position);

				Quaternion q = Quaternion.FromToRotation(Vector3.up, rotation_to);
				GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject; // create bullet as a new gameObject
				go = Instantiate(bulletPrefab, transform.position - new Vector3(0.5f, 0, 0), q) as GameObject; // create clones
				go = Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0, 0), q) as GameObject;
			}
		}
	}

}
