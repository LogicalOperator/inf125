using UnityEngine;
using System.Collections;

public class enemyController : enemyBase {

    void Start()
    {
        maxHP = 10f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 1;
        speed = 2f;
    }

    void Update()
    {
        movement();//use default enemy movement
    }

}
