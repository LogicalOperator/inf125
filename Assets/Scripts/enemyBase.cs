using UnityEngine;
using System.Collections;
//Base class for all enemies 
public class enemyBase : MonoBehaviour {

    public ParticleSystem deathEffect;
    public float maxHP; //maxHP given to enemy in child
    public GameObject player; //player object, for ai purposes
    public AudioClip eClip;//random audioclip for death sounds//animation sounds etc.
    public float currentHP;//current HP enemy has
    public float speed;//current speed enemy has
    public float dmg;
    public GameObject money;
    public GameObject healthPack;
    public int level;
    public bool wander = true;

    public float Health//health function to quickly update hp and destory itself if it is 0;
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;

            if (Health <= 0)
            {
                destroySelf();
            }
        }
    }
    public void takeDamage(float damage)//damage function to minus their hp from damage taken
    {
        Health -= damage;
        audioManager.instance.playSound(eClip, transform.position);
    }

    public virtual void destroySelf() //increment score and destory itself, can be overridden
    {
        scoreChanger.instance.AddPoints(level*Random.Range(10,20));
        if(Random.Range(1,10) <= 2)
        {
            GameObject aHealthPack = Instantiate(healthPack);
            aHealthPack.transform.position = this.transform.position;
        }
        else
        {
            GameObject aMoneyDrop = Instantiate(money);
            aMoneyDrop.transform.position = this.transform.position;
        }

        Destroy(Instantiate(deathEffect.gameObject,this.transform.position,this.transform.rotation),deathEffect.startLifetime);
        Destroy(gameObject);
    }

    public virtual void movement() //default movement which chase player, can be overridden
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find main player
        if (player)
        {
            Vector2 mainCharPos = player.transform.position; // get player locations and movetowards it.
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, speed * Time.deltaTime);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D colli)
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find main player
        if (colli.gameObject.tag == "Bullet")
        {
            float magnitude = 5500f;
            var force = transform.position - colli.transform.position;

            force.Normalize();
            GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            takeDamage(colli.gameObject.GetComponent<baseBullet>().damage); //take damage of bullet movement
            audioManager.instance.playSound("Impact", player.transform.position);//play damage sound at audioListener position
        }
    }

    public virtual void sendRaycast()
    {
        Vector3 startPosition = transform.position;
        Vector3 target = Vector3.zero;

        int angle = 180;

        int startAngle = (int)(-angle * 0.5f);
        int finishAngle = (int)(angle * 0.5f);

        int inc = (int)(angle / 10);
        RaycastHit hit;

        for(int i = startAngle; i < finishAngle; i += inc)
        {
            target = (Quaternion.Euler(0, i, 0) * transform.forward).normalized * 5.0f;
            if(Physics.Raycast(startPosition, target, out hit))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    wander = false;
                    Debug.Log("Player found");
                }
            }
            Debug.DrawLine(startPosition, target, Color.green);
        }
    }
    
}
