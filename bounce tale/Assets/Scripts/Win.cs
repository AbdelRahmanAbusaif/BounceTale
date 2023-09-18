using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Win : MonoBehaviour
{
    private GameManager game;
    void Start()
    {
        game = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            game.PalyerWin();
    }
}
