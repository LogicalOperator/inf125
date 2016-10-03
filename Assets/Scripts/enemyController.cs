using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    void Start()
    {
        maxHP = 10;
        currentHP = maxHP;
        speed = 2;
    }

    void Update()
    {
        movement();
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.tag == "Bullet")
        {
            takeDamage(colli.gameObject.GetComponent<bulletMovement>().damage);
            AudioSource.PlayClipAtPoint(eClip, Camera.main.transform.position, 10f);
        }
    }
}
