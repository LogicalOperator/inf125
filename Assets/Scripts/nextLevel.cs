using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {
    public manager managerFinder;
    public static bool winCondition = false;

    void Start()
    {
        managerFinder = GameObject.Find("managerGameObject").GetComponent<manager>();//get Manager script
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);//destory portal 
            winCondition = true;
            SceneManager.LoadScene(3);
        }
    }

}
