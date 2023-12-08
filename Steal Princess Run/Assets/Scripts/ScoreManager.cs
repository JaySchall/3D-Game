using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreManagerUI scoreManagerUI;
    public ScoreManagerUI highscoreManagerUI;
    int currentScore = 0;
    int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        currentScore += points;
        scoreManagerUI.UpdateScoreText();
        if (currentScore >= highScore)
        {
            highScore = currentScore;
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

    public void ResetScore()
    {
        currentScore = 0;
    }
}
