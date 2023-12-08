using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public ScoreManager scoreManager;

    void Start()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
        highScoreText.text = "HighScore: " + scoreManager.GetHighScore().ToString();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = "HighScore: " + scoreManager.GetHighScore().ToString();
    }
}