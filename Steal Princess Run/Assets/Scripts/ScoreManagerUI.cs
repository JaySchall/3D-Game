using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagerUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
      //  highscoreText = "HighScore: " + highscore.GetScore().toString();
    }


    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreManager.GetScore().ToString();
      //  highscoreText.text = "Highscore: " + scoreManager.GetScore().ToString();
    }
}
