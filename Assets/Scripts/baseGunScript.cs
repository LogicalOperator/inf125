using UnityEngine;
using System.Collections;

public class baseGunScript : MonoBehaviour {
    //base stuff needed for a gun
    public AudioClip gunSound;
    public GameObject bulletPrefab;
    public string gunType;
    public int dmgMod = 0;
    public string gunName;
    public Sprite gunImage;
	

    public virtual void summonBullet()
    {
        if (Input.GetMouseButtonDown(0)) //when ever mouse left mouse button is clicked down 
        {
            AudioSource.PlayClipAtPoint(gunSound, Camera.main.transform.position, 10f);
            Vector3 pos = Input.mousePosition; //obtain mousepostion
            pos = Camera.main.ScreenToWorldPoint(pos);//obtain exact mouse position from main camera screen
            pos.z = transform.position.z;

            Quaternion q = Quaternion.FromToRotation(Vector3.up, pos - transform.position);
            GameObject go = Instantiate(bulletPrefab, transform.position, q) as GameObject;//create bullet as a new gameObject
        }
    }
}
