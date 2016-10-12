using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class controller : MonoBehaviour
{
    public float baseDamage = 10;
    public float damage = 10;
    public TrailRenderer trail;
    public float speed = 0.5f;//current speed, might lower later
    public Rigidbody2D mainBody;
    public AudioClip deathClip;
    public baseGunScript currentGun;
    public baseGunScript secondaryGun;
    public GameObject hpBar;
    public GameObject gunSelector;
    public float maxHP = 100;
    public float hp;
    // Use this for initialization
    void Start()
    {
        currentGun = GetComponent<initialGun>();
        secondaryGun = GetComponent<machineGun>();
        updateDamage(currentGun);
        secondaryGun.enabled = false;//turn second gun off at the start
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "foreground"; //trailer had layer problems had to set it correctly
        trail.sortingOrder = 4;
        mainBody = GetComponent<Rigidbody2D>();
        hp = maxHP;
        gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(currentGun.gunImage); // update UI to display gun


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        changeGun();
        mainBody.velocity = new Vector2( //obtains horizontal and vertical calls default is wsad, can be changed manually later
        Input.GetAxis("Horizontal") * speed,
        Input.GetAxis("Vertical") * speed);
    }

    void OnCollisionStay2D(Collision2D obj)//detects collisions with obj as the obj it collided with
    {
        if (obj.gameObject.tag == "Enemy") //if it crashes object with a tag enemy, kill itself move to Gameover scene
        {
            enemyBase currentEnemy = obj.gameObject.GetComponent<enemyBase>();
            hp -= currentEnemy.dmg; //getEnemy dmg
            float calculateHP = hp / maxHP;//calcualte percentage of fill for hpBar
            setHealthBar(calculateHP);
            if(hp <= 0)
            {
                SceneManager.LoadScene(3);//gameOver Screen
            }
        }
    }

    void updateDamage(baseGunScript gunModifer)
    {
        //count the current gun dmg with self dmg
        if(gunModifer.dmgMod == 0) //added base DMG in case the gun is weaker 
        {
            damage = baseDamage;
        }
        else
        {
            damage += gunModifer.dmgMod;
        }
    }

    public void setHealthBar(float myHealth) // change hpBar depending on dmg
    {
        hpBar.transform.localScale = new Vector3(myHealth, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
    }

    public void changeGun()
    {
        if (Input.GetKeyDown(KeyCode.R)) // if R is pressed
        {
            if(currentGun.enabled)//check if current gun is active
            {
                currentGun.enabled = false; //if so deactivate it, and activate secondary gun
                secondaryGun.enabled = true;
                gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(secondaryGun.gunImage);//change UI
                updateDamage(secondaryGun);//change dmg depending on gun
            }
            else
            {
                currentGun.enabled = true;
                secondaryGun.enabled = false;
                gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(currentGun.gunImage);
                updateDamage(currentGun);

            }

        }
    }
}
