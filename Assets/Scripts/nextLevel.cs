using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {
    public manager managerFinder;

    void Start()
    {
        managerFinder = GameObject.Find("managerGameObject").GetComponent<manager>();//get Manager script
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("score", scoreChanger.scoreint);
            PlayerPrefs.SetInt("gold", goldChanger.gold);
            PlayerPrefs.SetInt("winCondition", 1);
            Destroy(gameObject);//destory portal 
            SceneManager.LoadScene(3);
        }
    }

}
