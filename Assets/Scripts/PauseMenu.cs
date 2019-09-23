using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject thePauseMenu;

    public void RestartGame()
    {
        Time.timeScale = 1f;
         thePauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().RestartGame();

       
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
        Application.LoadLevel(mainMenuLevel);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {   
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
