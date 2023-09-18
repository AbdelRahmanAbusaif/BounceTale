using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheakPoint : MonoBehaviour
{
    GameManager game;
    AudioManager audiomanager;
    void Start()
    {
        game = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
   void OnTriggerEnter2D(Collider2D collider)
   {
        if (collider.CompareTag("Player"))
        {
            game.UpdateCheckPoint(transform.position);
            audiomanager.PlayMusic(audiomanager.PowerUpClip);
        }
   }
}
