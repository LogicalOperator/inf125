using UnityEngine;
using System;
using System.Collections.Generic;       
using Random = UnityEngine.Random;    

public class enemySpawner : MonoBehaviour {

    public GameObject[]    enemies;
    public Vector3[]       spawnLocations;

    public int maxEnemies; // max amount of enemies to spawn          
    public float maxSecsStartSpawner; //max time it takes to spawn enemy

    public static int waveRemaining;

    public void initializeSpawner(Vector3[] locs, GameObject[] enemies) {
        maxEnemies = 0;
        maxSecsStartSpawner = 3f;
        this.spawnLocations = locs;
        this.enemies = enemies;
    }

    public void setMaxEnemies(int amt) {
        maxEnemies      = amt;
        waveRemaining   = amt;
    }

   

    // Use this for initialization
    void Start () {
        //maxEnemies = 0;
        //maxSecsStartSpawner = 3f;
	}

    public void startSpawner() {
        Invoke("spawner", maxSecsStartSpawner);
    }

    // takes an index of an enemy and returns that enemy as an
    // instantiated GameObject. If the index does not exist,
    // returnes enemies[0]
    private GameObject setupEnemy(int index) {
        GameObject enemy;
        if (index > enemies.Length) {
            enemy = (GameObject)Instantiate(enemies[0]);
        } else {
            enemy = (GameObject)Instantiate(enemies[index]);
        }
        return enemy;
    }


    public void spawner() {
        GameObject anEnemy = setupEnemy(0);
        anEnemy.transform.position = spawnLocations[Random.Range(0, 3)]; //move enemy position to one of the random respawn locations
        waveRemaining--; // decrement wave amount
        schedulerforEnemySpwn();
    }

    //funciton to time when to call the next spawn of enemy
    void schedulerforEnemySpwn() {
        float spwnInNSeconds;

        if (maxSecsStartSpawner > 1f) {
            spwnInNSeconds = Random.Range(1f, maxSecsStartSpawner);//random time of 1 - 3 secs for next enemy
        }
        else {
            spwnInNSeconds = 1f;
        }

        if (waveRemaining <= 0) { //if wave <= 0 create portal to enter next level
            return;
        }
        else { //if wave still has more respawn new enemy
            Invoke("spawner", spwnInNSeconds);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
