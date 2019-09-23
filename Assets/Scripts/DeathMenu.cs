using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameManager theGameManager;
    public Text finalPoints;

    public void RestartGame(){
        theGameManager.RestartGame();
    }

    public void QuitToMainMenu()
    {
        Application.LoadLevel(mainMenuLevel);
    }

    public void ShowFinalPoints(float points)
    {
        finalPoints.text = "You : " + Mathf.Round(points);
    }
}
