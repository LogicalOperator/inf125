using UnityEngine;
using System.Collections;
//Base class for all enemies 
public class enemyBase : MonoBehaviour {

    public int maxHP; //maxHP given to enemy in child
    public GameObject player; //player object, for ai purposes
    public AudioClip eClip;//random audioclip for death sounds//animation sounds etc.
    public int currentHP;//current HP enemy has
    public int speed;//current speed enemy has
    public int Health//health function to quickly update hp and destory itself if it is 0;
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
    public void takeDamage(int damage)//damage function to minus their hp from damage taken
    {
        Health -= damage;
        AudioSource.PlayClipAtPoint(eClip, Camera.main.transform.position, 10f);
    }

    public virtual void destroySelf() //increment score and destory itself, can be overridden
    {
        scoreChanger.scoreint += 20;
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
}
