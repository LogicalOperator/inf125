using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour {
    public AnimationClip creditAnimation;
	// Use this for initialization
	void Start () {
        StartCoroutine(animationTimer());
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    IEnumerator animationTimer()
    {
        yield return new WaitForSeconds(35);
        SceneManager.LoadScene("gameOver");

    }
}
