using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class death_screen : MonoBehaviour
{
    public GameObject death;
    public TMP_Text scoreText;
    public TMP_Text titleText;
    public TMP_Text timerText;
    public TMP_Text highscoreText;

    public scoreCounter scorecount;
    public timer time;

    private bool ended;

    // Start is called before the first frame update
    void Start()
    {
        ended = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!time.timerRunning && !ended)
        {
            int oldHighScore = PlayerPrefs.GetInt("highscore");
            if (scorecount.score > oldHighScore)
            {
                PlayerPrefs.SetInt("highscore", scorecount.score);
            }
            timeRunOut();
            ended = true;
        }
        if (scorecount.dead && !ended)
        {
            int oldHighScore = PlayerPrefs.GetInt("highscore");
            if (scorecount.score > oldHighScore)
            {
                PlayerPrefs.SetInt("highscore", scorecount.score);
            }
            died();
            ended = true;
        }
    }

    public void died()
    {
        scoreText.text = "Time remaining: " + timerText.text;
        titleText.text = "You ran out of parts!";
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
        death.SetActive(true);
        Time.timeScale = 0f;
    }

    public void timeRunOut()
    {
        scoreText.text = "Score: " + scorecount.score;
        titleText.text = "You survived the night!";
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
        death.SetActive(true);
        Time.timeScale = 0f;
    }

    public void home()
    {
        Debug.Log("home_pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void replay()
    {
        Debug.Log("replay_pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
