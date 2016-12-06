using UnityEngine;
using System.Collections;

public class impScript : enemyBase
{
    public GameObject fireball;
    public Vector3 rotation_to;
    public float fireRate;
    public float playerDistance;
    public float rotationDampening;
    private float nextFire = 0.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireRate = 0.8f;
        maxHP = 10f; //max hp of enemy
        currentHP = maxHP; //make currentHp = to max
        dmg = 1f;
        speed = 1f;
        level = PlayerPrefs.GetInt("level", 1);
    }

    void Update()
    {
        movement();
    }

    public override void movement()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (playerDistance < 17f)
        {
            lookAtPlayer();
            if(Time.time > nextFire)
            {
                Vector3 pos = new Vector3();
                Vector3 rotation_to = new Vector3();
                pos = player.transform.position;
                pos.z = transform.position.z;
                rotation_to = pos - transform.position;
                nextFire = Time.time + nextFire;
                
                Quaternion q = Quaternion.FromToRotation(Vector3.up, rotation_to);
                GameObject afireball = Instantiate(fireball, transform.position, q) as GameObject; // create bullet as a new gameObject
            }
            Vector2 mainCharPos = player.transform.position;
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, speed * Time.deltaTime);
        }
        else
        {
            lookAtPlayer();
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
