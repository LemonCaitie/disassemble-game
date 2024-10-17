using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioSource music;
    public Slider volSlider;


    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            music.volume = PlayerPrefs.GetFloat("volume");
            if (volSlider != null) volSlider.value = PlayerPrefs.GetFloat("volume");
        }

        else
        {
            PlayerPrefs.SetFloat("volume", 1.0f);
            music.volume = PlayerPrefs.GetFloat("volume");
        }
    }

    public void setVolume (float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        music.volume = PlayerPrefs.GetFloat("volume");
    }
}
