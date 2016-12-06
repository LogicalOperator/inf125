using UnityEngine;
using System.Collections;
using System;

public class bagOfHammers : baseGunScript
{

    // Use this for initialization
    void Awake()
    {
        gunName = "bagOfHammers"; //update gunname, dmg mod, firing rate and other things here
        fireRate = 0.8f;
        gunType = "light";
        gunTypeValue = 5f;
        player = GameObject.FindGameObjectWithTag("Player");
        libraryIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        specialFire();
        summonBullet();
    }

    public override void specialFire()//speical fire for max resource
    {

        Vector3 pos = new Vector3();
        Vector3 rotation_to = new Vector3();

        if (Input.GetMouseButtonDown(1) 
		|| (Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K)))
		|| (Input.GetKey("joystick button 5") && (Input.GetAxis("HorFire") != 0 || Input.GetAxis("VerFire") != 0) && (Input.GetJoystickNames() != null || Input.GetJoystickNames().Length != 0))){
            if (player.GetComponent<controller>().currentLight < 100)//check if max light, if not play not full sound
            {
                audioManager.instance.playSound(emptyGunSound, transform.position);
            }
            else
            {
				rotation_to = new Vector3(Input.GetAxis("HorFire"), Input.GetAxis("VerFire"), 0);
                if (Input.GetMouseButtonDown(1))
                {
                    pos = Input.mousePosition; // obtain mousepostion
                    pos = Camera.main.ScreenToWorldPoint(pos); // obtain exact mouse position from main camera screen
                    pos.z = transform.position.z;

                    rotation_to = pos - transform.position;
                }
                else
                {
                    if (Input.GetKey(KeyCode.J))
                    {
                        rotation_to = Vector3.left;
                    }
                    if (Input.GetKey(KeyCode.L))
                    {
                        rotation_to += Vector3.right;
                    }
                    if (Input.GetKey(KeyCode.I))
                    {
                        rotation_to += Vector3.up;
                    }
                    if (Input.GetKey(KeyCode.K))
                    {
                        rotation_to += Vector3.down;
                    }
                }


                player.GetComponent<controller>().resetBars(); //reset both resources
                audioManager.instance.playSound(gunSound, transform.position);

                Quaternion q = Quaternion.FromToRotation(Vector3.up, rotation_to);
                GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject; // create bullet as a new gameObject
            }
        }
    }
}
