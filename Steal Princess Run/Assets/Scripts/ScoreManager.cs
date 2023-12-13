using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public ScoreManagerUI scoreManagerUI;
    public ScoreManagerUI highscoreManagerUI;
    int currentScore = 0;
    int highScore = 0;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Main")
        {
            Debug.Log("Main");
            currentScore = 0;
            PlayerPrefs.SetInt("Score", currentScore);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log(currentScore);
            currentScore = PlayerPrefs.GetInt("Score", 0);
        }
        // Load high score from player preferences or another source.
        
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreManagerUI.UpdateHighScoreText(); // Update the UI with the loaded high score.
        scoreManagerUI.UpdateScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();
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