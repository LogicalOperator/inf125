using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {
    public GameObject enemy;
    public float maxSecsStartSpawner = 3f;
	// Use this for initialization
	void Start () {
        Invoke("enemySpawner", maxSecsStartSpawner);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void enemySpawner()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

        GameObject anEnemy = (GameObject)Instantiate(enemy);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

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

        Invoke("enemySpawner",spwnInNSeconds);
    }
}
