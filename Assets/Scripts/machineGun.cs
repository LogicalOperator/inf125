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
        if (Input.GetMouseButtonDown(1))
        {
            if (player.GetComponent<controller>().currentDark < 100)//check if dark light, if not play not full sound
            {
                AudioSource.PlayClipAtPoint(emptyGunSound, Camera.main.transform.position, 10f);
            }
            else
            {
                player.GetComponent<controller>().resetBars();//reset both resources
                AudioSource.PlayClipAtPoint(gunSound, Camera.main.transform.position, 10f);
                Vector3 pos = Input.mousePosition; // obtain mousepostion
                pos = Camera.main.ScreenToWorldPoint(pos); // obtain exact mouse position from main camera screen
                pos.z = transform.position.z;

                Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
                GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject; // create bullet as a new gameObject
                go = Instantiate(bulletPrefab, transform.position-new Vector3(0.5f,0,0), q) as GameObject; // create clones
                go = Instantiate(bulletPrefab, transform.position+new Vector3(0.5f,0,0), q) as GameObject;

            }
        }
    }

}
