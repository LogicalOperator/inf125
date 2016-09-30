using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D mainBody;
    public AudioSource mainAudioS;
    public AudioClip deathClip;
    // Use this for initialization
    void Start()
    {
        mainAudioS = GetComponent<AudioSource>();
        mainBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        mainBody.velocity = new Vector2(
        Input.GetAxis("Horizontal") * speed,
        Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(deathClip,Camera.main.transform.position, 10f);
            Destroy(gameObject);
        }
    }
}
