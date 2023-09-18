using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] AudioManager audiomanager;
    void Start()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            active();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        FruitCount.Score++;
        //Destroy gameobject
        //make sount effect here 
        gameObject.SetActive(false);
        audiomanager.PlayMusic(audiomanager.FruitClip);
    }
    public void active()
    {
        gameObject.SetActive(true);
    }

}