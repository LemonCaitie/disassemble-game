using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Image blackOut;
    public Animator fadeAnim;

    public GameObject settings;
    public GameObject credits;
    public GameObject instructions;

    public AudioSource audioSource;
    public Slider volSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("volume");
            volSlider.value = PlayerPrefs.GetFloat("volume");
        }

        else
        {
            PlayerPrefs.SetFloat("volume", 1.0f);
            audioSource.volume = PlayerPrefs.GetFloat("volume");
        }
    }

public void Startbtn()
    {
        //StartCoroutine(FadeOut());
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Debug.Log("Will quit");
        Application.Quit();
    }

    public void openSettings()
    {
        Debug.Log("settings open");
        settings.SetActive(true);
    }

    public void closeSettings()
    {
        Debug.Log("settings close");
        settings.SetActive(false);
    }

    public void openCredits()
    {
        Debug.Log("credits open");
        credits.SetActive(true);
    }

    public void closeCredits()
    {
        Debug.Log("credits close");
        credits.SetActive(false);
    }

    public void openInstructions()
    {
        Debug.Log("instructions open");
        instructions.SetActive(true);
    }

    public void closeInstructions()
    {
        Debug.Log("instructions close");
        instructions.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => blackOut.color.a == 1);
        SceneManager.LoadScene(1);
    }
}
