using UnityEngine;
using System.Collections;

public class bigZombie : enemyBase
{

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find main player
        maxHP = 100f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 1f;
        speed = 1f;
        level = PlayerPrefs.GetInt("level", 1);
    }

    void Update()
    {
        movement();//use default enemy movement
    }

    public override void movement()
    {
        lookAtPlayer();
        if (player)
        {
            Vector2 mainCharPos = player.transform.position;//get player locations and movetowards it.
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, speed * Time.deltaTime);
        }

    }

    void lookAtPlayer()
    {
        // LookAt 2D
        // get the angle
        Vector3 norTar = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;

    }

}
