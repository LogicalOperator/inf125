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

}
