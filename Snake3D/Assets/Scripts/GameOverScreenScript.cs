using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{
    public Text CurrentScoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScoreText.text = "Current Score: " + GameObject.FindObjectOfType<ScoreManager>().GetCurrentScore();
    }

    public void OnContinueButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
