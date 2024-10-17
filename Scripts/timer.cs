using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    private float time = 300.00f;
    public TMP_Text timerText;

    public bool timerRunning;

    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;

        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            if (minutes > 0 | seconds > 0)
            {
                time -= Time.deltaTime;
                //change to a clock

                minutes = Mathf.FloorToInt(time / 60);
                seconds = Mathf.FloorToInt(time % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                //timerText.text = time.ToString("#.00");
            }
            else
            {
                Debug.Log("Death!!");
                timerRunning = false;
            }
        }
    }
}
