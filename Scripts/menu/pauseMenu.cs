using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public static bool GamePaused = false;

    public GameObject settings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        settings.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        settings.SetActive(true);
        Time.timeScale = 0f;
    }

    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
