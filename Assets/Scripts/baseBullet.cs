using UnityEngine;
using System.Collections;

public class baseBullet : MonoBehaviour {
    controller player;
    public int damage;
    float speed = 10f;
    public int lifetimeBull = 10;
    // Use this for initialization
    protected void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
        damage = player.damage;
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed); // add force to bullet to move forward
        Destroy(gameObject, lifetimeBull); //destory gameobject if it passes x amount of time
    }

    public virtual void bulletMovement()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);// add force to bullet to move forward
    }

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);//destory itself if it touch anything
    }
}
