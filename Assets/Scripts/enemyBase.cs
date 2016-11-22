using UnityEngine;
using System.Collections;
//Base class for all enemies 
public class enemyBase : MonoBehaviour {

    public float maxHP; //maxHP given to enemy in child
    public GameObject player; //player object, for ai purposes
    public AudioClip eClip;//random audioclip for death sounds//animation sounds etc.
    public float currentHP;//current HP enemy has
    public float speed;//current speed enemy has
    public float dmg;
    public GameObject money;
    //float timeIsUp = 50.0f;
    //float timeNow = 1.0f;
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
        scoreChanger.scoreint += 20;
        GameObject aMoneyDrop = Instantiate(money);
        aMoneyDrop.transform.position = this.transform.position;
        Destroy(gameObject);
    }

    public virtual void movement() //default movement which chase player, can be overridden
    {
        player = GameObject.FindGameObjectWithTag("Player"); //find main player
        if (player)
        {
            Vector2 mainCharPos = player.transform.position;//get player locations and movetowards it.
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, speed* Time.deltaTime);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "Bullet")
        {

            takeDamage(colli.gameObject.GetComponent<baseBullet>().damage); //take damage of bullet movement
            audioManager.instance.playSound("Impact", player.transform.position);//play damage sound at audioListener position
            //fixedKnockBack();
        }
    }

    //public virtual void fixedKnockBack()
    //{
    //    while (true)
    //    {
    //        if (timeNow >= timeIsUp)
    //        {
    //            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    //            timeNow = 0;
    //            Debug.Log("hi");
    //            break;
    //        }
    //        if (timeNow < timeIsUp)
    //        {
    //            timeNow += Time.deltaTime;
    //        }
    //    }
    //}
}
