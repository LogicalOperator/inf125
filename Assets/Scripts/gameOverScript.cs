using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOverScript : MonoBehaviour {
    //script used to get the static score off other screen
    float pointAnimDurationSec = 2f;
    float pointAnimTimer = 0f;
    float currentScore = 0;
    float savedDisplayedScore = 0;
    float displayedScore = 0;
    float fakeScoreKeeper;
    int goldInt;
    public Text gameOver;
    public Text gold;
    public Text score;
    public Text totalScore;
	// Use this for initialization
	void Awake () {

        getScore();
        AddPoints(fakeScoreKeeper);
    }

    void Update()
    {
        pointAnimTimer += Time.deltaTime;
        float prcComplete = pointAnimTimer / pointAnimDurationSec;
        // don't modify the start and end values here 
        // prcComplete will grow linearly but if you change the start/end points
        // it will add a cumulating error
        displayedScore = Mathf.Lerp(savedDisplayedScore, currentScore, prcComplete);
        totalScore.text = "Total Score: " + (int)displayedScore;
    }

    void getScore()
    {

        if (PlayerPrefs.GetInt("winCondition") == 1)
        {
            fakeScoreKeeper = 1000;
            gameOver.text = "You Win!";
        }
        else
        {
            gameOver.text = "You Lose!";
        }

        if (PlayerPrefs.HasKey("score"))
        {
            if(PlayerPrefs.GetInt("gold",0) > 0)
            {
                score.text = "Score: " + PlayerPrefs.GetInt("score", 0);
                gold.text = "Gold: " + PlayerPrefs.GetInt("gold", 0);
                fakeScoreKeeper += PlayerPrefs.GetInt("score",0) + PlayerPrefs.GetInt("gold",0);
            }
            else
            {
                gold.text = "Gold: 0";
                score.text = "Score: " + PlayerPrefs.GetInt("score", 0);
                fakeScoreKeeper += PlayerPrefs.GetInt("score");
            }
        }
        else
        {
            goldInt = PlayerPrefs.GetInt("gold", 0);
            fakeScoreKeeper = 0 + goldInt;
        }
    }

    void AddPoints(float points)
    {
        // A
        // what if you get more points before last points finished animating ?
        // start the animation again but from the score that was already being shown
        // --> no sudden jump in score animation
        savedDisplayedScore = displayedScore;
        // B
        // the player instantly has these points so nothng gets 
        // messed up if e.g. level ends before score animation finishes
        currentScore += points;
        // Lerp gets a new end point
        pointAnimTimer = 0f;
    }

}
