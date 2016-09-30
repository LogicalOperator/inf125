using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour {

	public void goToScene()
    {
        SceneManager.LoadScene(1);
    }
}
