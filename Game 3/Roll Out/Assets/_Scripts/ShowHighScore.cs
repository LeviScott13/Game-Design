//Levi Sutton

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    public Text achievedHighScoreText;
    string initials = "";
    int score;

    // Start is called before the first frame update
    void Start()
    {
        achievedHighScoreText.text = "";
        score = PlayerPrefs.GetInt("Player Score");
        PlayerPrefs.SetInt("High Score", score);
    }

    // Update is called once per frame
    void Update()
    {
        highScore();
    }
    public void highScore()
    {
        achievedHighScoreText.text = "High Score: " + score + " sec.";
    }
    void OnGUI()
    {
        initials = GUI.TextField(new Rect(480, 353, 100, 20), initials, 25);
        PlayerPrefs.SetString("Name", initials);
    }
}
