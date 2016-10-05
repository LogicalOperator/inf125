using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {
    public manager managerFinder;

    void Start()
    {
        managerFinder = GameObject.Find("managerGameObject").GetComponent<manager>();//get Manager script
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        manager.waveRemaining = manager.waveInt[++manager.currentWave];//switch wave to next wave number in manager list of wave numbers
        managerFinder.enemySpawner();//invoke the enemy spawner function
        Destroy(gameObject);//destory portal 
    }

}
