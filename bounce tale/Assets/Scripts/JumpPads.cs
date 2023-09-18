using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPads : MonoBehaviour
{
    [SerializeField]float JumpPadsSpeed= 8f;
    AudioManager audiomanager;
    void Start()
    {
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
           {
             other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*JumpPadsSpeed,ForceMode2D.Impulse);
             audiomanager.PlayMusic(audiomanager.JumpPadsClip);   
           }
    }
}
