using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    void Start()
    {
        maxHP = 30f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 0.5f;
        speed = 2f;
    }

    void Update()
    {
        movement();//use default enemy movement
    }

}
