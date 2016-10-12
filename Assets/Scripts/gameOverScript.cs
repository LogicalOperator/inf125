using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {
    //script used to get the static score off other screen
    Text score;
    public Text gameOver;
	// Use this for initialization
	void Start () {
        score = GetComponent<Text>(); //get text object on canvas
        score.text = "Score: " + scoreChanger.scoreint;//change depending on the scorechanger script function
	}

    void Update()
    {
        if(nextLevel.winCondition == true)
        {
            gameOver.text = "Game Won";
        }
    }

}
