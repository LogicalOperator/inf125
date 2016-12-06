using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {

    controller player;
    void OnCollisionEnter2D(Collision2D coll)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<controller>();

        if (coll.gameObject.tag == "Player")
        {
            if(player.gunInventory[0].GetComponent<baseGunScript>().libraryIndex != 0 || player.gunInventory[1].GetComponent<baseGunScript>().libraryIndex != 1)
            {
                PlayerPrefs.SetInt("primaryGunIndex", player.gunInventory[0].GetComponent<baseGunScript>().libraryIndex);
                PlayerPrefs.SetInt("secondaryGunIndex", player.gunInventory[1].GetComponent<baseGunScript>().libraryIndex);
            }

            PlayerPrefs.SetInt("score", scoreChanger.instance.getScore());
            PlayerPrefs.SetInt("gold", goldChanger.gold);
            PlayerPrefs.Save();

            if(SceneManager.GetActiveScene().buildIndex == 9)
            {
                PlayerPrefs.SetInt("winCondition", 1);
                SceneManager.LoadScene("Credits");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            Destroy(gameObject);//destory portal 
        }
    }

}
