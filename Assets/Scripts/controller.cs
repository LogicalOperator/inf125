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
    public GameObject hpBar;
    public float maxHP = 100;
    public float hp;
    // Use this for initialization
    void Start()
    {
        currentGun = GetComponent<initialGun>();
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "foreground"; //trailer had layer problems had to set it correctly
        trail.sortingOrder = 4;
        mainBody = GetComponent<Rigidbody2D>();
        hp = maxHP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        mainBody.velocity = new Vector2( //obtains horizontal and vertical calls default is wsad, can be changed manually later
        Input.GetAxis("Horizontal") * speed,
        Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionStay2D(Collision2D obj)//detects collisions with obj as the obj it collided with
    {
        if (obj.gameObject.tag == "Enemy") //if it crashes object with a tag enemy, kill itself move to Gameover scene
        {
            enemyBase currentEnemy = obj.gameObject.GetComponent<enemyBase>();
            hp -= currentEnemy.dmg;
            float calculateHP = hp / maxHP;
            setHealthBar(calculateHP);
            if(hp <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    void updateDamage(baseGunScript gunModifer)
    {
        //count the current gun dmg with self dmg
        damage += gunModifer.dmgMod;
    }

    public void setHealthBar(float myHealth)
    {
        hpBar.transform.localScale = new Vector3(myHealth, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
    }
}
