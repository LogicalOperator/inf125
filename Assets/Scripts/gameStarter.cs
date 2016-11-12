using UnityEngine;
using System.Collections;

public class gameStarter : MonoBehaviour {
    public GameObject primary;
    public GameObject secondary;
    public baseGunScript savedGun;
    public baseGunScript savedGunTwo;
    public SpriteRenderer primaryGun;
    public SpriteRenderer secondaryGun;
	// Use this for initialization
	void Awake () { //when game starts set starting weapons
        primaryGun = primary.GetComponent<SpriteRenderer>();
        secondaryGun = secondary.GetComponent<SpriteRenderer>();
        getSavedGuns();
	}
	
    void getSavedGuns()
    {
        if (PlayerPrefs.HasKey("primaryGun") && PlayerPrefs.HasKey("secondaryGun")) //if new weapons exist from prev level get it
        {
            
            primary.AddComponent(System.Type.GetType(PlayerPrefs.GetString("primaryGun")));
            savedGun = (baseGunScript) primary.GetComponent(System.Type.GetType(PlayerPrefs.GetString("primaryGun")));
            primaryGun.sprite = savedGun.gunImage;
            secondary.AddComponent(System.Type.GetType(PlayerPrefs.GetString("secondaryGun")));
            savedGunTwo = (baseGunScript)primary.GetComponent(System.Type.GetType(PlayerPrefs.GetString("primaryGun")));
            secondaryGun.sprite = savedGun.gunImage;

        }
        else //else use the intro weapons
        {
            primary.AddComponent<initialGun>();
            primaryGun.sprite = primary.GetComponent<initialGun>().gunImage;

            secondary.AddComponent<machineGun>();
            secondaryGun.sprite = secondary.GetComponent<machineGun>().gunImage;
        }
    }
}
