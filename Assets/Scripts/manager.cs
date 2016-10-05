using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class manager : MonoBehaviour {
    public GameObject enemy;
    public GameObject door;
    public AudioClip portalSound;
    AudioSource portalSource;
    public float maxSecsStartSpawner = 3f;
    public static int waveRemaining;
    public static int currentWave = 0;
    public static List<int> waveInt;
    private GameObject[] respawnLocs;
    // Use this for initialization
    void Start () {
        respawnLocs = GameObject.FindGameObjectsWithTag("SpawnLoc");
        Invoke("enemySpawner", maxSecsStartSpawner);
        waveInt = new List<int> {10, 20, 25, 30, 35};
        waveRemaining = waveInt[currentWave];
        portalSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }

    public void enemySpawner()
    {

        GameObject anEnemy = (GameObject)Instantiate(enemy);
        anEnemy.transform.position = respawnLocs[Random.Range(0,3)].transform.position;
        waveRemaining--;
        schedulerforEnemySpwn();
    }

    void schedulerforEnemySpwn()
    {
        float spwnInNSeconds;

        if(maxSecsStartSpawner > 1f)
        {
            spwnInNSeconds = Random.Range(1f, maxSecsStartSpawner);
        }
        else
        {
            spwnInNSeconds = 1f;
        }

        if (waveRemaining == 0)
        {
            AudioSource.PlayClipAtPoint(portalSound, Camera.main.transform.position, 10f);

            GameObject aDoor = (GameObject)Instantiate(door);
            aDoor.transform.position = respawnLocs[Random.Range(0, 3)].transform.position;
        }

        else
        {
            Invoke("enemySpawner", spwnInNSeconds);
        }
    }
}
