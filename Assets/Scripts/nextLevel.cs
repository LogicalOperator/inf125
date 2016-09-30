using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {
    public manager managerFinder;

    void Start()
    {
        managerFinder = GameObject.Find("managerGameObject").GetComponent<manager>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        manager.waveRemaining = manager.waveInt[++manager.currentWave];
        managerFinder.enemySpawner();
        Destroy(gameObject);
    }

}
