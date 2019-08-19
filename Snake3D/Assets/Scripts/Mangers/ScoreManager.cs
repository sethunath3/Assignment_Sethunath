using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : GenericMonoSingleton<ScoreManager>
{
    int score;
    int streak;

    public Text scoreText;
    public Text streakText;

    public Text highScoreText;

    public GameObject scoreCardPanel;
    public GameObject gameOverPanel;

    private int highScore;
    void Start()
    {
        score = 0;
        streak = 1;
        scoreText.text = "Score: " + score;
        streakText.text = "Streak: " + streak;
        highScore = PlayerPrefs.GetInt ("highscore", 0);
        highScoreText.text = "HighScore: " + highScore;
        gameOverPanel.SetActive(false);
    }

    public void AddUpScoreWithOffset(int foodScore)
    {
        score = score + (foodScore * streak);
        scoreText.text = "Score: " + score;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            highScoreText.text = "HighScore: " + score;
        }

    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void IncrementStreak()
    {
        streak++;
        streakText.text = "Streak: " + streak;
    }

    public void ResetStreak()
    {
        streak = 1;
        streakText.text = "Streak: " + streak;
    }

    public void TriggerGameOver()
    {
        scoreCardPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    void Update()
    {
        
    }
}
