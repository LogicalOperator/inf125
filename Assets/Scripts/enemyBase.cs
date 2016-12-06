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
    
}
