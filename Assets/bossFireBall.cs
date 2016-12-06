using UnityEngine;
using System.Collections;

public class bossFireBall : MonoBehaviour
{
    controller player;
    public float damage = 15;
    public float speed = 5f;
    public int lifetimeBull = 10;
    // Use this for initialization
    protected void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed); // add force to bullet to move forward
        Destroy(gameObject, lifetimeBull); //destory gameobject if it passes x amount of time
    }

    public void Update()
    {
        bulletMovement();
    }

    public virtual void bulletMovement()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);// add force to bullet to move forward
    }

    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<controller>().takeDamage(5f);
            audioManager.instance.playSound2D("fire");
        }
        Destroy(gameObject);//destory itself if it touch anything
    }
}
