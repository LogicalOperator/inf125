using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    void Start()
    {
        maxHP = 10; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        speed = 2;
    }

    void Update()
    {
        movement();//use default enemy movement
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.tag == "Bullet")
        {
            takeDamage(colli.gameObject.GetComponent<bulletMovement>().damage); //take damage of bullet movement
            AudioSource.PlayClipAtPoint(eClip, Camera.main.transform.position, 10f);//play damage sound at audioListener position(on main camera)
        }
    }
}
