using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Deth;
    public GameObject[] Fruit;
    public GameObject[] Door;
    public Animator AnimCheck;
    //dont forget to set the start Position 
    private Vector2 startpos;
    private Vector2 pos2;
    private Vector2[] posDoor;

    void Start()
    {
        startpos = Player.transform.position;
        pos2 = startpos;
        for (int i = 0; i < Door.Length; i++)
        {
            posDoor[i] = Door[i].transform.position;
        }

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();
    }
    public void UpdateCheckPoint(Vector2 pos)
    {
        if (Health.HealthCount > 0)
        {
            startpos = pos;
            AnimCheck.SetBool("Active", true);
            //restore HealthCount
        }
    }
    public void Die()
    {
        Instantiate(Deth, Player.transform.position, Quaternion.identity);

        Player.SetActive(false);

        Invoke("respawn", 1f);

    }

    void respawn()
    {
        //game over
        if (Health.HealthCount <= 0)
        {
            Player.transform.position = pos2;
            Player.SetActive(true);
            Health.HealthCount = 3;
            startpos = pos2;
            AnimCheck.SetBool("Active", false);
            FruitCount.Score = 0;

            //active 
            for (int i = 0; i < Fruit.Length; i++)
            {
                Fruit[i].SetActive(true);
            }

            for (int i = 0; i < Door.Length; i++)
            {
                Door[i].transform.position = posDoor[i];
            }

        }
        else
        {
            Player.transform.position = startpos;
            Player.SetActive(true);
        }

    }

    public void PalyerWin() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
}
