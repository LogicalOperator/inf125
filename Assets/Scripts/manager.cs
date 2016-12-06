using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour {
    public bool spawner;
    public GameObject door;
    public float maxSecsStartSpawner = 3f;//max time it takes to spawn enemy
    public static int waveRemaining;
    public int waveMax;
    public int initialSpawn;

    private Vector3[] spawnLocations;
    public GameObject[] enemies;
    public GameObject player;

    public GameObject pauseMenu;
    private boardManager board;
    public int level;
    
    // Use this for initialization
    void Awake () {
        board = GetComponent<boardManager>();
        if (board == null)
        {

        }
        else
        {
            PlayerPrefs.SetInt("level", level);
            board.setupScene(level);
            spawnLocations = board.spawnLocs;
            player = GameObject.FindGameObjectWithTag("Player");
            enemies = board.enemyTiles;
        }

        if(spawner == true)
        {
            StartCoroutine(waitTimer());
        }
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

    // takes an index of an enemy and returns that enemy as an
    // instantiated GameObject. If the index does not exist,
    // returns enemies[0]
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

    public void enemySpawner()
    {
        GameObject anEnemy = setupEnemy(Random.Range(0,enemies.Length)); //spawn enemy
        Vector3 loc = spawnLocations[Random.Range(0, 3)];
        int unitRadius = 5 * 5; // used for a 5 unit radius (circle)
        if ((player.transform.position - loc).sqrMagnitude >= unitRadius)
        {
            anEnemy.transform.position = loc;   // move enemy to random spawn location
            waveRemaining--;                    // decrement wave amount
            schedulerforEnemySpwn();
        }
        else
        {
            schedulerforEnemySpwn();
        }
    }


    //funciton to time when to call the next spawn of enemy
    void schedulerforEnemySpwn()
    {
        float spwnInNSeconds;

        if(waveRemaining/waveMax <= 0.7)
        {
            if(maxSecsStartSpawner > 1)
            {
                maxSecsStartSpawner--;
            }
        }
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
            audioManager.instance.playSound2D("portal");
            GameObject aDoor = (GameObject)Instantiate(door);
            aDoor.transform.position = spawnLocations[Random.Range(0, 3)];
        }

        else //if wave still has more respawn new enemy
        {
            Invoke("enemySpawner", spwnInNSeconds);
        }
    }

    //void startSpawner(int index)
    //{
    //    Vector3 loc = spawnLocations[Random.Range(0, 3)];
    //    int unitRadius = 5 * 5; // used for a 5 unit radius (circle)
    //    for(int i = 0; i < index; i++)
    //    {
    //        GameObject anEnemy = setupEnemy(Random.Range(0, enemies.Length));
    //        if ((player.transform.position - loc).sqrMagnitude >= unitRadius)
    //        {
    //            anEnemy.transform.position = loc;   // move enemy to random spawn location
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //}

    IEnumerator waitTimer()
    {
        audioManager.instance.playSound2D("spawnTimer");
        yield return new WaitForSeconds(3);
        board.spawnInitialEnemies(3);
        waveRemaining = waveMax;
        Invoke("enemySpawner", maxSecsStartSpawner); //calls function enemy Spawner for x amount of seconds
    }
}
