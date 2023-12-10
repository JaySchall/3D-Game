using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreManagerUI scoreManagerUI;
    public ScoreManagerUI highscoreManagerUI;
    int currentScore = 0;
    int highScore = 0;

    void Start()
    {
        // Load high score from player preferences or another source.
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreManagerUI.UpdateHighScoreText(); // Update the UI with the loaded high score.
    }

    public void AddScore(int points)
    {
        currentScore += points;
        scoreManagerUI.UpdateScoreText();
        if (currentScore > highScore)
        {
            SetHighscore(currentScore);
            highscoreManagerUI.UpdateHighScoreText();
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetHighScore()
    {
        return highScore;
    }
    public void SetHighscore(int newHighscore)
    {
        highScore = newHighscore;
        PlayerPrefs.SetInt("Highscore", newHighscore);
        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        currentScore = 0;
        // You may choose to save the high score to player preferences or another source here.
    }
}