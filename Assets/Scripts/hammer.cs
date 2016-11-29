using UnityEngine;
using System.Collections;

public class hammer : baseBullet {
    public Transform target;
    private Vector3 zAxis = new Vector3(0, 0, 1);

    // Use this for initialization
    new void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
        damage = player.damage;
        Destroy(gameObject, lifetimeBull);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletMovement();
    }

    public override void bulletMovement()
    {
        transform.RotateAround(target.position, zAxis, speed);
    }
}
