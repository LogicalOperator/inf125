using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour {
    public GameObject enemy;
    public GameObject door;
    public AudioClip portalSound;
    public float maxSecsStartSpawner = 3f;//max time it takes to spawn enemy
    public static int waveRemaining;
    private GameObject[] respawnLocs;
    public GameObject pauseMenu;

    private boardManager board;
    private int level = 3;
    
    // Use this for initialization
    void Awake () {
        board = GetComponent<boardManager>();
        board.setupScene(level);
        respawnLocs = GameObject.FindGameObjectsWithTag("SpawnLoc"); //list of all respawn locations
        Invoke("enemySpawner", maxSecsStartSpawner); //calls function enemy Spawner for x amount of seconds
        waveRemaining = 10;
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

    public void resumeGame() // resume button
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void enemySpawner()
    {

        GameObject anEnemy = (GameObject)Instantiate(enemy); //spawn enemy
        anEnemy.transform.position = respawnLocs[Random.Range(0,3)].transform.position;//move enemy position to one of the random respawn locations
        waveRemaining--; // decrement wave amount
        schedulerforEnemySpwn();
    }

    //funciton to time when to call the next spawn of enemy
    void schedulerforEnemySpwn()
    {
        float spwnInNSeconds;

        if(maxSecsStartSpawner > 1f)
        {
            spwnInNSeconds = Random.Range(1f, maxSecsStartSpawner);//random time of 1 - 3 secs for next enemy
        }
        else
        {
            spwnInNSeconds = 1f;
        }

        if (waveRemaining <= 0) //if wave <= 0 create portal to enter next level
        {
            AudioSource.PlayClipAtPoint(portalSound, Camera.main.transform.position, 10f);

            GameObject aDoor = (GameObject)Instantiate(door);
            aDoor.transform.position = respawnLocs[Random.Range(0, 3)].transform.position;
        }

        else //if wave still has more respawn new enemy
        {
            Invoke("enemySpawner", spwnInNSeconds);
        }
    }
}
