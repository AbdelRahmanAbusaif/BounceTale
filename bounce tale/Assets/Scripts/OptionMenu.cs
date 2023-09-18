using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionMenu : MonoBehaviour
{
    public Slider VoulumeSlider;  
    public Slider MusicSlider;
    public AudioMixer myaudiomixer;
    void start()
    {
        if(PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
        }
        else 
           SetMusicVolume();

    }
     
    void Load()
    {
        MusicSlider.value=PlayerPrefs.GetFloat("music");
        MusicSlider.value=PlayerPrefs.GetFloat("volume");
    }
    public void SetMusicVolume()
    {
        float volume = MusicSlider.value;
        myaudiomixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("music",volume);
    }
    public void SetVolumeVolume()
    {
        float volume = VoulumeSlider.value;
        myaudiomixer.SetFloat("volume", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("volume",volume);
    }
}
