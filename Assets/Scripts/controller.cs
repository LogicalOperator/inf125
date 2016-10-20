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
    public GameObject lightBar;
    public GameObject darkBar;
    public GameObject gunSelector;
    public string gunType;
    public float resourceValue;
    public float maxLight = 100;
    public float currentLight;
    public float maxDark = 100;
    public float currentDark;
    public float maxHP = 100;
    public float hp;
    // Use this for initialization
    void Start()
    {
        currentGun = GetComponent<initialGun>();
        secondaryGun = GetComponent<machineGun>();
        updateGun(currentGun);
        secondaryGun.enabled = false;//turn second gun off at the start
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "foreground"; //trailer had layer problems had to set it correctly
        trail.sortingOrder = 4;
        mainBody = GetComponent<Rigidbody2D>();
        hp = maxHP;
        gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(currentGun.gunImage); // update UI to display gun
        currentLight = 0;
        currentDark = 0;
        lightBar.transform.localScale = new Vector3(currentLight, lightBar.transform.localScale.y, lightBar.transform.localScale.z);
        darkBar.transform.localScale = new Vector3(currentDark, darkBar.transform.localScale.y, darkBar.transform.localScale.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(gunType + " " + resourceValue + " " + damage);
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

    void updateGun(baseGunScript gun)
    {
        gunType = gun.gunType; //update guns type and resource value of the gun
        resourceValue = gun.gunTypeValue;

        //count the current gun dmg with self dmg
        if (gun.dmgMod == 0) //added base DMG in case the gun is weaker 
        {
            damage = baseDamage;
        }
        else
        {
            damage += gun.dmgMod;
        }

    }

    public void setHealthBar(float myHealth) // change hpBar depending on dmg
    {
        hpBar.transform.localScale = new Vector3(myHealth, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
    }

    public void setResourceBar()
    {
        if(gunType == "light") //check gun type e.g light/dark
        {
            if(currentLight <= (maxLight - resourceValue)) // if resource is less than max
            {
                if (currentDark > 50) //minuses opposite resource if that resource > half
                {
                    currentDark -= resourceValue;
                    float myDark = currentDark / maxDark;
                    darkBar.transform.localScale = new Vector3(myDark, darkBar.transform.localScale.y, darkBar.transform.localScale.z);
                }
                currentLight += resourceValue; // increase resource
            }
            else
            {
                currentLight = 100;
            }

            float myLight = currentLight / maxLight;
            lightBar.transform.localScale = new Vector3(myLight, lightBar.transform.localScale.y, lightBar.transform.localScale.z);
        }
        else
        {
            if (currentDark <= (maxDark - resourceValue)) // same as above but dark version
            {
                if(currentLight > 50)
                {
                    currentLight -= resourceValue;
                    float myLight = currentLight / maxLight;
                    lightBar.transform.localScale = new Vector3(myLight, lightBar.transform.localScale.y, lightBar.transform.localScale.z);
                }
                currentDark += resourceValue;
            }
            else
            {
                currentDark = 100;
            }

            float myDark = currentDark / maxDark;
            darkBar.transform.localScale = new Vector3(myDark, darkBar.transform.localScale.y, darkBar.transform.localScale.z);
        }
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
                updateGun(secondaryGun);//change dmg depending on gun
            }
            else
            {
                currentGun.enabled = true;
                secondaryGun.enabled = false;
                gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(currentGun.gunImage);
                updateGun(currentGun);

            }

        }
    }

    public void resetBars()
    {
        currentLight = 0;
        currentDark = 0;
        lightBar.transform.localScale = new Vector3(currentLight, lightBar.transform.localScale.y, lightBar.transform.localScale.z);
        darkBar.transform.localScale = new Vector3(currentDark, darkBar.transform.localScale.y, darkBar.transform.localScale.z);
    }
}
