using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour
{
    public int damage = 10;
    float speed = 10f;
    public int lifetimeBull = 10;

    // Use this for initialization

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        Destroy(gameObject, lifetimeBull);
    }

    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);
    }

}
