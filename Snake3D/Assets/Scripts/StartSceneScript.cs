using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public Text highScoreText;
    void Start()
    {
        highScoreText.text = "Top Score: " + PlayerPrefs.GetInt ("highscore", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayGameButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
