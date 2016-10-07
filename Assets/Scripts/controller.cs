using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public int damage = 10;
    public TrailRenderer trail;
    public float speed = 0.5f;//current speed, might lower later
    public Rigidbody2D mainBody;
    public AudioClip deathClip;
    public baseGunScript currentGun;
    // Use this for initialization
    void Start()
    {
        currentGun = GetComponent<initialGun>();
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "foreground"; //trailer had layer problems had to set it correctly
        trail.sortingOrder = 4;
        mainBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        mainBody.velocity = new Vector2( //obtains horizontal and vertical calls default is wsad, can be changed manually later
        Input.GetAxis("Horizontal") * speed,
        Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionEnter2D(Collision2D obj)//detects collisions with obj as the obj it collided with
    {
        if (obj.gameObject.tag == "Enemy") //if it crashes object with a tag enemy, kill itself move to Gameover scene
        {
            
            Destroy(gameObject);
            SceneManager.LoadScene(3);
            
        }
    }

    void updateDamage(baseGunScript gunModifer)
    {
        damage += gunModifer.dmgMod;
    }
}
