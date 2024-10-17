using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class scoreCounter : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    public fall_apart shotsLeft;
    public bool dead = false;

    //audio stuff
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shotsLeft.getCount() == -1 && score == 0)
        {
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("projectile");
            if (projectiles.Length == 0 && !dead)
            {
                Debug.Log("Dead!!!");
                dead = true;
            }
        }
    }

    public void increaseScore(int increase)
    {
        hitSound.Play();
        score += increase;
        scoreText.text = score.ToString("");
    }

    public void decreaseScore(int decrease)
    {
        score -= decrease;
        scoreText.text = score.ToString("");
    }


    //need to add implementation
    private void setHighScore()
    {

    }

    private void getHighScore()
    {

    }

    private void updateScoreUI()
    {

    }

    private void updateHighScoreUI()
    {

    }
}
