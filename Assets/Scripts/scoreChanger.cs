using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreChanger : MonoBehaviour {
    public Text MainScore;
    public static int scoreint;

    void Awake()
    {
        MainScore = GetComponent<Text>();
        scoreint = 0; //initialize score as 0
    }

    void Update()
    {
        MainScore.text = "Score : " + scoreint;
    }
}
