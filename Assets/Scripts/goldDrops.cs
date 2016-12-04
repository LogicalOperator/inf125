using UnityEngine;
using System.Collections;

public class goldDrops : MonoBehaviour {
    Transform player;
    bool inside;
    float radius = 5f;
    float force = 100f;
    public int time;
    public int worth;
    public AudioClip goldClip;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        time = 15;
        worth = Random.Range(1, 10);
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
