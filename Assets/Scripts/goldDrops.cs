using UnityEngine;
using System.Collections;

public class goldDrops : MonoBehaviour {
    public int time;
    public int worth;
    public AudioClip goldClip;
	// Use this for initialization
	void Start () {
        time = 15;
        worth = Random.Range(1, 10);
        DestroyObject(this, time);
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
}
