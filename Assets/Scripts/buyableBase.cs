using UnityEngine;
using System.Collections;

public class buyableBase : MonoBehaviour {
    public int gunIndex;
    public int goldCost;
    public string gunType;
    public controller player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (goldChanger.gold >= goldCost)
            {
                goldChanger.gold -= goldCost;
                audioManager.instance.playSound2D("bought");
                if (gunType == "light")
                {
                    if(player.gunInventory[0].GetComponent<baseGunScript>().gunType == "light")
                    {
                        Destroy(player.gunInventory[0]);
                        player.currentGun = gunLibrary.instance.findGun(gunIndex);
                        GameObject firstGun = Instantiate(player.currentGun);
                        player.updateGun(firstGun.GetComponent<baseGunScript>());
                        firstGun.transform.position = player.transform.position;
                        firstGun.transform.position += new Vector3(0.1f, 0, 0);
                        firstGun.transform.parent = player.transform;
                        player.gunInventory[0] = firstGun;
                        player.gunInventory[0].SetActive(true);
                        player.gunInventory[1].SetActive(false);

                    }
                    else
                    {
                        Destroy(player.gunInventory[1]);
                        player.secondaryGun= gunLibrary.instance.findGun(gunIndex);
                        GameObject firstGun = Instantiate(player.secondaryGun);
                        player.updateGun(firstGun.GetComponent<baseGunScript>());
                        firstGun.transform.position = player.transform.position;
                        firstGun.transform.position += new Vector3(0.1f, 0, 0);
                        firstGun.transform.parent = player.transform;
                        player.gunInventory[1] = firstGun;
                        player.gunInventory[1].SetActive(true);
                        player.gunInventory[0].SetActive(false);
                    }
                }
                else
                {
                    if (player.gunInventory[1].GetComponent<baseGunScript>().gunType == "dark")
                    {
                        Destroy(player.gunInventory[1]);
                        player.secondaryGun = gunLibrary.instance.findGun(gunIndex);
                        GameObject secondGun = Instantiate(player.secondaryGun); //create it
                        secondGun.transform.position = player.transform.position; //move it to player
                        secondGun.transform.position += new Vector3(0.1f, 0, 0);
                        secondGun.transform.parent = player.transform;
                        player.gunInventory[1] = secondGun;
                        player.gunInventory[1].SetActive(true);
                        player.gunInventory[0].SetActive(false);

                    }
                    else
                    {
                        Destroy(player.gunInventory[0]);
                        player.currentGun = gunLibrary.instance.findGun(gunIndex);
                        GameObject secondGun = Instantiate(player.currentGun); //create it
                        secondGun.transform.position = player.transform.position; //move it to player
                        secondGun.transform.position += new Vector3(0.1f, 0, 0);
                        secondGun.transform.parent = player.transform;
                        player.gunInventory[0] = secondGun;
                        player.gunInventory[0].SetActive(true);
                        player.gunInventory[1].SetActive(false);
                    }
                }

                Destroy(gameObject);
            }
            else
            {
                audioManager.instance.playSound2D("error");
            }
        }
    }
}
