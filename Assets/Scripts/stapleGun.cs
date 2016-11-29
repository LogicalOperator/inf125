using UnityEngine;
using System.Collections;

public class stapleGun : baseGunScript
{

    // Use this for initialization
    void Awake()
    {
        gunName = "Staple Gun";
        fireRate = 0.5f;
        gunType = "light";
        gunTypeValue = 3f;
        player = GameObject.FindGameObjectWithTag("Player");
        libraryIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        summonBullet();
        specialFire();
    }

    public override void specialFire()//speical fire for max resource
    {

        Vector3 pos = new Vector3();
        Vector3 rotation_to = new Vector3();

        if (Input.GetMouseButton(1) || (Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))))
        {
            if (player.GetComponent<controller>().currentLight < 100)//check if max light, if not play not full sound
            {
                audioManager.instance.playSound(emptyGunSound, transform.position);
            }
            else
            {
                if (Input.GetMouseButton(1))
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
                go = Instantiate(bulletPrefab, transform.position - new Vector3(0.5f, 0, 0), q) as GameObject; // create clones
                go = Instantiate(bulletPrefab, transform.position + new Vector3(0.5f, 0, 0), q) as GameObject;
            }
        }
    }
}
