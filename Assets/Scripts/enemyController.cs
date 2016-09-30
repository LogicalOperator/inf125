using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    public AudioSource mainAudioS;
    public AudioClip eClip;
    public GameObject player;

    void Start()
    {
        mainAudioS = GetComponent<AudioSource>();
        player = GameObject.Find("character");
    }

    void Update()
    {
        player = GameObject.Find("character");
        if (player)
        {
            Vector2 mainCharPos = player.transform.position;
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mainCharPos, 0.025f);
        }
        else
        {

        }
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        

        if(colli.gameObject.tag == "Enemy")
        {

        }
        else if(colli.gameObject.tag == "Wall")
        {

        }
        else
        {
            scoreChanger.scoreint += 20;
            mainAudioS.clip = eClip;
            AudioSource.PlayClipAtPoint(eClip, Camera.main.transform.position, 10f);
            Destroy(gameObject);
        }
    }
}
