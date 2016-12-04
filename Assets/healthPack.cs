using UnityEngine;
using System.Collections;

public class healthPack : MonoBehaviour {
    Transform player;
    bool inside;
    public int time;
    public int worth;
    public AudioClip healthClip;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        time = 15;
        worth = Random.Range(10, 30);
        DestroyObject(gameObject, time);
    }

    public void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "Player")
        {
            audioManager.instance.playSound(healthClip, transform.position);
            colli.gameObject.GetComponent<controller>().heal(worth);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
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
