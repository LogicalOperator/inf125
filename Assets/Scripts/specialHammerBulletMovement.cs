using UnityEngine;
using System.Collections;

public class specialHammerBulletMovement : baseBullet {

    // Use this for initialization
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        bulletMovement();
    }

    new public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            player.setResourceBar();//increase resource when bullet hit enemy
        }
    }
}
