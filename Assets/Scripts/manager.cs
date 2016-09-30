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
    // Use this for initialization
    void Start () {
        Invoke("enemySpawner", maxSecsStartSpawner);
        waveInt = new List<int> {10, 20, 25, 30, 35,};
        waveRemaining = waveInt[currentWave];
        portalSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void enemySpawner()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

        GameObject anEnemy = (GameObject)Instantiate(enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
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
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

            GameObject aDoor = (GameObject)Instantiate(door);
            aDoor.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

        else
        {
            Invoke("enemySpawner", spwnInNSeconds);
        }
    }
}
