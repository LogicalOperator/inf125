using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour {
    public GameObject[] enemies;
    public GameObject door;
    public AudioClip portalSound;
    public float maxSecsStartSpawner = 3f;//max time it takes to spawn enemy
    public static int waveRemaining;
    private Vector3[] respawnLocs;
    public GameObject pauseMenu;

    private boardManager board;
    private enemySpawner spawner;
    private int level = 3;
    
    // Use this for initialization
    void Start () {
        board = GetComponent<boardManager>();
        board.setupScene(level);
        respawnLocs = board.spawnLocs; //list of all respawn locations
        enemies = GameObject.FindGameObjectsWithTag("")
        spawner = GetComponent<enemySpawner>();
        spawner.initializeSpawner(respawnLocs, enemies);
        //Invoke("enemySpawner", maxSecsStartSpawner); //calls function enemy Spawner for x amount of seconds
        waveRemaining = 10;
        spawner.setMaxEnemies(waveRemaining);
        spawner.startSpawner();
        AudioSource.PlayClipAtPoint(portalSound, Camera.main.transform.position, 10f);
        GameObject aDoor = (GameObject)Instantiate(door);
        aDoor.transform.position = respawnLocs[Random.Range(0, 3)];
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

   
}
