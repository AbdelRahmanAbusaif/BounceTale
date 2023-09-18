using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionMenu : MonoBehaviour
{
    public Slider VoulumeSlider;
    public Slider MusicSlider;

    [SerializeField]
    AudioMixer myAudiomixer;

    void start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
        }
        else
        {
            SetMusicVolume();
        }
    }

    void Load()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("music");
        MusicSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetMusicVolume()
    {
        float musicVolume = MusicSlider.value;
        myAudiomixer.SetFloat("music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("music", musicVolume);
    }

    public void SetVolumeVolume()
    {
        float sliderVolume = VoulumeSlider.value;
        myAudiomixer.SetFloat("volume", Mathf.Log10(sliderVolume) * 20);
        PlayerPrefs.SetFloat("volume", sliderVolume);
    }
}
