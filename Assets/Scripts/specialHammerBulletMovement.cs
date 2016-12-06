using UnityEngine;
using System.Collections;

public class specialHammerBulletMovement : baseBullet {

    // Use this for initialization
    new void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
        damage = player.damage + 3;
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed); // add force to bullet to move forward
        Destroy(gameObject, lifetimeBull); //destory gameobject if it passes x amount of time
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
