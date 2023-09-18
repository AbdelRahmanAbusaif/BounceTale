using UnityEngine;
using UnityEngine.SceneManagement;
public class Spike : Fruit
{
    private GameManager game;
    private AudioManager audiomanager;

    void Start()
    {
        game = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        game.Die();
        Health.HealthCount -= 1;
        audiomanager.PlayMusic(audiomanager.DeathClip);
    }

}
