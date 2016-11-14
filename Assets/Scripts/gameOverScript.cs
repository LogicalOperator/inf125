using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {
    //script used to get the static score off other screen
    Text score;
    int mainScore;
    public Text gameOver;
	// Use this for initialization
	void Start () {
        getScore();
        score = GetComponent<Text>(); //get text object on canvas
        score.text = "Score: " + mainScore;//change depending on the scorechanger script function
	}


    void getScore()
    {

        if (PlayerPrefs.HasKey("winCondition"))
        {
            mainScore += 1000;
            gameOver.text = "You Win!";
        }
        else
        {
            gameOver.text = "You Lose!";
        }

        if (PlayerPrefs.HasKey("score"))
        {
            mainScore = PlayerPrefs.GetInt("score");
        }
        else
        {
            mainScore = 0;
        }
    }

}
