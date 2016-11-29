using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreChanger : MonoBehaviour {
    public Text MainScore;
    public static int scoreint;

    void Awake()
    {
        scoreint = PlayerPrefs.GetInt("score", 0);
        MainScore = GetComponent<Text>();
    }

    void Update()
    {
        MainScore.text = "Score : " + scoreint;
    }
}
