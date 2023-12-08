using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public ScoreManager scoreManager;
    public ScoreManager highscoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
        HighScoreText.text = "HighScore: " + highscoreManager.GetHighScore().ToString();
    }


    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
    }
    public void UpdateHighScoreText()
    {
        HighScoreText.text = "Highscore: " + highscoreManager.GetHighScore().ToString();
    }
}
