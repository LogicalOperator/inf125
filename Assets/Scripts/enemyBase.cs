using UnityEngine;
using System.Collections;

public class enemyBase : MonoBehaviour {

    public int maxHP;
    public GameObject player;
    AudioSource mainAudioS;
    public AudioClip eClip;
    public int currentHP;
    public int speed;
    public int Health
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
	// Use this for initialization
	void Start () {
        mainAudioS = GetComponent<AudioSource>();
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        AudioSource.PlayClipAtPoint(eClip, Camera.main.transform.position, 10f);
    }

    public virtual void destroySelf()
    {
        scoreChanger.scoreint += 20;
        Destroy(gameObject);

    }

    public virtual void movement()
    {
        player = GameObject.Find("character");
        if (player)
        {
            Vector2 mainCharPos = player.transform.position;
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, speed* Time.deltaTime);
        }
    }
}
