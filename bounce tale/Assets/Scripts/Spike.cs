using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : Fruit
{
    GameManager Game;
    AudioManager audiomanager;
    void Start()
    {
        Game = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audiomanager=GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //player return to checkPoint
        if(collision.gameObject.CompareTag("Player"))
        {            
            Game.Die();
            Health.health-=1;
            audiomanager.PlayMusic(audiomanager.DeathClip);
        }
    }

}
