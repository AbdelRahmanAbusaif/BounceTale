using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clip")]
    [SerializeField]public AudioClip musicClip;
    [SerializeField]public AudioClip DeathClip;
    [SerializeField]public AudioClip JumpClip;
    [SerializeField]public AudioClip KeyClip;
    [SerializeField]public AudioClip FruitClip;
    [SerializeField]public AudioClip JumpPadsClip;
    [SerializeField]public AudioClip PowerUpClip;

    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }
    public void PlayMusic(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
