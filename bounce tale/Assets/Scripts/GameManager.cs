using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Deth;
    public GameObject []Fruit;
    public GameObject []Door;
    //dont forget to set the start Position 
    Vector2 Startpos;
    Vector2 Pos2;
    Vector2 []posDoor;

    public Animator animCheck;
    void Start()
    {
        Startpos=Player.transform.position;
        Pos2 = Startpos;
        for (int i = 0; i < Door.Length; i++)
        {
             posDoor[i]=Door[i].transform.position;
        }
           
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            Restart();
    }
    public void UpdateCheckPoint(Vector2 pos)
    {   
        if(Health.health > 0)
        {
            Startpos=pos;
            animCheck.SetBool("Active", true);
            //restore health
        }
    }
    public void Die()
    {
        Instantiate(Deth,Player.transform.position,Quaternion.identity);

        Player.SetActive(false);
        
        Invoke("respawn",1f);
             
    }

    void respawn()
    {
        
        //game over
        if(Health.health<=0)
        {
            Player.transform.position = Pos2;
            Player.SetActive(true);
            Health.health = 3;
            Startpos=Pos2;
            animCheck.SetBool("Active", false);
            FruitCount.Score=0;
            //active 
            for(int i=0;i<Fruit.Length;i++) 
                Fruit[i].SetActive(true);
            for (int i = 0; i < Door.Length; i++)
            {
                Door[i].transform.position=posDoor[i];
            }
               
        }
        else
        {
            Player.transform.position = Startpos;
            
            Player.SetActive(true);
        } 
        
    }
    public void PalyerWin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  
}
