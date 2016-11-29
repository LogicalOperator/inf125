using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {
    //script used to get the static score off other screen
    Text score;
    int mainScore;
    public Text gameOver;
	// Use this for initialization
	void Awake () {
        getScore();
        score = GetComponent<Text>(); //get text object on canvas
        score.text = "Score: " + mainScore;//change depending on the scorechanger script function
    }


    void getScore()
    {

        if (PlayerPrefs.GetInt("winCondition") == 1)
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
            if(PlayerPrefs.GetInt("gold") > 0)
            {
                mainScore = PlayerPrefs.GetInt("score") + PlayerPrefs.GetInt("gold");
            }
            else
            {
                mainScore = PlayerPrefs.GetInt("score");
            }
        }
        else
        {
            mainScore = 0;
        }
    }

}
