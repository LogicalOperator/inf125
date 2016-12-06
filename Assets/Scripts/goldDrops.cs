using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goldDrops : MonoBehaviour {
    public Sprite gold1;
    public Sprite gold2;
    public Sprite gold3;
    Transform player;
    bool inside;
    
    public int time;
    public int worth;
    public AudioClip goldClip;
	// Use this for initialization
	void Start () {

        worth = Random.Range(1, 10);
        if(worth <= 3)
        {
           GetComponent<SpriteRenderer>().sprite = gold1;
        }
        else if(worth >3 && worth<= 6)
        {
            GetComponent<SpriteRenderer>().sprite = gold2;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = gold3;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        time = 15;
        DestroyObject(gameObject, time);
	}

    void FixedUpdate()
    {
        if (inside)
        {
            Vector2 mainCharPos = player.transform.position;//get player locations and movetowards it.
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, 2 * Time.deltaTime);
        }
    }
    public void OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.tag == "Player")
        {
            audioManager.instance.playSound(goldClip, transform.position);
            goldChanger.gold += worth;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            inside = false;
           
        }
    }


}
