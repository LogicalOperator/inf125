using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour
{
    float speed = 10f;

    // Use this for initialization

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
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
