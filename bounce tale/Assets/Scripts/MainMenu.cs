using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void MainMenuStart()
    {
        SceneManager.LoadScene("MainMenu");
        FindAnyObjectByType<PausManu>().GetComponent<PausManu>().ResumeGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void QuitGame()
    {
        print("Quitting"); //Quitting
        Application.Quit();
    }
}
