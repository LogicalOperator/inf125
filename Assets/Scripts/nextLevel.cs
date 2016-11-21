using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {
    baseGunScript gun1;
    baseGunScript gun2;

    void OnCollisionEnter2D(Collision2D coll)
    {
        gun1 = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().currentGun.GetComponent<baseGunScript>();
        gun2 = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>().secondaryGun.GetComponent<baseGunScript>();
        if (coll.gameObject.tag == "Player")
        {
            if(gun1.libraryIndex != 0 && gun2.libraryIndex != 1)
            {
                PlayerPrefs.SetInt("primaryGunIndex", gun1.libraryIndex);
                PlayerPrefs.SetInt("secondaryGunIndex", gun2.libraryIndex);
            }

            PlayerPrefs.SetInt("score", scoreChanger.scoreint);
            PlayerPrefs.SetInt("gold", goldChanger.gold);
            PlayerPrefs.SetInt("winCondition", 1);
            PlayerPrefs.Save();
            Destroy(gameObject);//destory portal 
            SceneManager.LoadScene(3);
        }
    }

}
