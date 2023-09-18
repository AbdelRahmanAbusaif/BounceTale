using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausManu : MonoBehaviour
{   
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUi;
    public GameObject PlayerMovement;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
                ResumeGame();
            else 
                PauseGame();
        }
    }
    public void ResumeGame()
    {  
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void PauseGame()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
