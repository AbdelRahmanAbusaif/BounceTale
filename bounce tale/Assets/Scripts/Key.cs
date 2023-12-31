using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Key : MonoBehaviour
{
    public DooeControl Door;
    // public Rigidbody2D dooe2;
    public Animator Anim;

    [SerializeField]
    AudioManager audiomanager;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Door = GetComponent<DooeControl>();
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
            return;

        //Move door Up
        DooeControl.ToggleDoor();
        gameObject.SetActive(false);
        audiomanager.PlayMusic(audiomanager.KeyClip);

    }
}
