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
        obtainGuns();
        updateGun(currentGun);
        trail = GetComponent<TrailRenderer>();
        trail.sortingLayerName = "foreground"; //trailer had layer problems had to set it correctly
        trail.sortingOrder = 4;
        mainBody = GetComponent<Rigidbody2D>();
        gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(currentGun.gunImage); // update UI to display gun
        hp = maxHP;
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
        rotation();
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

    public void rotation()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
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
                if (currentDark > 1) //minuses opposite resource if that resource > 1
                {
                    currentDark -= resourceValue;
                    if(currentDark < 0)
                    {
                        currentDark = 0;
                    }
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
                if(currentLight > 1)
                {
                    currentLight -= resourceValue;
                    if (currentLight < 0)
                    {
                        currentLight = 0;
                    }
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
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                    updateGun(child.GetComponent<baseGunScript>());
                    gunSelector.GetComponent<gunSelectorUI>().UpdateGunImage(child.GetComponent<baseGunScript>().gunImage);
                }
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

    public void obtainGuns() {
        foreach(Transform child in transform)
        {
            getGun(child.GetComponent<baseGunScript>());
            if (secondaryGun && currentGun)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void getGun(baseGunScript gun)
    {
        if (currentGun)
        {
            secondaryGun = gun;
        }
        else
        {
            currentGun = gun;
        }
    }
}
