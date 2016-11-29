using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour {
    public GameObject enemy;
    public GameObject door;
    public GameObject player;
    public AudioClip portalSound;
    public float maxSecsStartSpawner = 3f;//max time it takes to spawn enemy
    public static int waveRemaining;
    //private GameObject[] respawnLocs;

    private Vector3[] spawnLocations;
    public GameObject[] enemies;

    public GameObject pauseMenu;

    private boardManager board;
    private int level = 3;
    
    // Use this for initialization
    void Awake () {
        board = GetComponent<boardManager>();
        board.setupScene(level);
        //respawnLocs = GameObject.FindGameObjectsWithTag("SpawnLoc"); //list of all respawn locations
        spawnLocations = board.spawnLocs;
        player = GameObject.Find("player"); // get the player
        Invoke("enemySpawner", maxSecsStartSpawner); //calls function enemy Spawner for x amount of seconds
        waveRemaining = 10;
        // v REFACTOR
        enemies = new GameObject[1];
        enemies[0] = enemy; 
        // ^ REFACTOR
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("winCondition");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) //if esc is pressed pause game 
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else //if game already paused continue game
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    // takes an index of an enemy and returns that enemy as an
    // instantiated GameObject. If the index does not exist,
    // returnes enemies[0]
    GameObject setupEnemy(int index) {
        GameObject enemy;
        if (index > enemies.Length) {
            enemy = (GameObject)Instantiate(enemies[0]);
        }
        else {
            enemy = (GameObject)Instantiate(enemies[index]);
        }
        return enemy;
    }

    public void resumeGame() // resume button
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }



    public void enemySpawner()
    {
        GameObject anEnemy = setupEnemy(0); //spawn enemy
        Vector3 loc = spawnLocations[Random.Range(0, 3)];
        int unitRadius = 5 * 5; // used for a 5 unit radius (circle)
        if ((player.transform.position - loc).sqrMagnitude >= unitRadius) {
            anEnemy.transform.position = loc;   // move enemy to random spawn location
            waveRemaining--;                    // decrement wave amount
            schedulerforEnemySpwn();
        } else {
            return;
        } 
    }

    //funciton to time when to call the next spawn of enemy
    void schedulerforEnemySpwn()
    {
        float spwnInNSeconds;

        if(maxSecsStartSpawner > 1f) {
            spwnInNSeconds = Random.Range(1f, maxSecsStartSpawner);//random time of 1 - 3 secs for next enemy
        } else {
            spwnInNSeconds = 1f;
        }

        if (waveRemaining <= 0) { //if wave <= 0 create portal to enter next level
            AudioSource.PlayClipAtPoint(portalSound, Camera.main.transform.position, 10f);
            GameObject aDoor = (GameObject)Instantiate(door);
            aDoor.transform.position = spawnLocations[Random.Range(0, 3)];
        } else { //if wave still has more respawn new enemy 
            Invoke("enemySpawner", spwnInNSeconds);
        }
    }
}
