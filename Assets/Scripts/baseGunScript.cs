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

    private float nextFire = 0.0f;

    public virtual void summonBullet()
    {
        
        if (Input.GetMouseButton(0) && Time.time > nextFire) // when ever mouse left mouse button is clicked down 
        {
            nextFire = Time.time + fireRate; // only displays new bullet when correct amount of time has passed
            AudioSource.PlayClipAtPoint(gunSound, Camera.main.transform.position, 10f);
            Vector3 pos = Input.mousePosition; // obtain mousepostion
            pos = Camera.main.ScreenToWorldPoint(pos); // obtain exact mouse position from main camera screen
            pos.z = transform.position.z;

            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject; // create bullet as a new gameObject
        }
    }

    public abstract void specialFire(); // specialFire for secondaryfire
}
