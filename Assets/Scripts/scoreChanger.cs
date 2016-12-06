using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreChanger : MonoBehaviour {
    float pointAnimDurationSec = 2f;
    float pointAnimTimer = 0f;
    float currentScore = 0;
    float savedDisplayedScore = 0;
    float displayedScore = 0;
    public static scoreChanger instance;
    Text MainScore;

    void Awake()
    {
        instance = this;
        currentScore = PlayerPrefs.GetInt("score", 0);
        
        MainScore = GetComponent<Text>();
    }

    void Update()
    {
        pointAnimTimer += Time.deltaTime;
        float prcComplete = pointAnimTimer / pointAnimDurationSec;
        displayedScore = Mathf.Lerp(savedDisplayedScore, currentScore, prcComplete);
        MainScore.text = "Score: " + (int)displayedScore;

    }

    public void AddPoints(float points)
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

    public int getScore()
    {
        return (int)currentScore;
    }



}
