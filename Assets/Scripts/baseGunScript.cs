using UnityEngine;
using System.Collections;

public abstract class baseGunScript : MonoBehaviour {
    //base stuff needed for a gun
    public AudioClip gunSound;
    public AudioClip emptyGunSound;
    public GameObject bulletPrefab;
    public GameObject player;
    public float gunTypeValue;
    public string gunType;
    public float dmgMod = 0;
    public string gunName;
    public Sprite gunImage;
    public float fireRate; // fire rate for the bullet
    public int libraryIndex;

    private float nextFire = 0.0f;

    public virtual void summonBullet()
    {
		Vector3 pos = new Vector3();
		Vector3 rotation_to = new Vector3();

		if (Time.time > nextFire && (Input.GetMouseButton(0) 
		|| (!Input.GetKey(KeyCode.RightShift) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L) || Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))) 
		|| (Input.GetJoystickNames() != null) && Input.GetAxis("HorFire") != 0 && Input.GetAxis("VerFire") != 0)) {
			if(Input.GetJoystickNames() != null)
			if(Input.GetJoystickNames() != null)
			{
				rotation_to = new Vector3(Input.GetAxis("HorFire"), Input.GetAxis("VerFire"), 0);
			}
			else if (Input.GetMouseButton(0)) {			
				pos = Input.mousePosition; // obtain mousepostion
				pos = Camera.main.ScreenToWorldPoint(pos); // obtain exact mouse position from main camera screen
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


			nextFire = Time.time + fireRate; // only displays new bullet when correct amount of time has passed
			audioManager.instance.playSound(gunSound, transform.position);
			Quaternion q = Quaternion.FromToRotation(Vector3.up, rotation_to);
			GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject; // create bullet as a new gameObject
		}

    }

    public abstract void specialFire(); // specialFire for secondaryfire
}
