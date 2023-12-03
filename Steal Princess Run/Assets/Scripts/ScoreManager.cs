using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScoreManagerUI scoreManagerUI;
    int currentScore = 0;
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
    }
    public int GetScore()
    {
        return currentScore;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
