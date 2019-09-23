using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform plataformGenerator;
    private Vector3 plataformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlataformDestroyer[] plataformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    void Start()
    {
        plataformStartPoint = plataformGenerator.position;

        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

        theDeathScreen.gameObject.SetActive(false);

        theScoreManager.ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.setScoreIncreasing(false);
        theDeathScreen.gameObject.SetActive(false);
        theScoreManager.ShowScores();
       Reset();
    }

    public void OnPlayerDied()
    {
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);
        theDeathScreen.ShowFinalPoints(theScoreManager.GetScoreCount());
        theScoreManager.OnPlayerDye();
        theScoreManager.HideScores();
    }

    public void Reset(){
        plataformList = FindObjectsOfType<PlataformDestroyer>();

        for( int i = 0; i < plataformList.Length; i++){
            plataformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        plataformGenerator.position = plataformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.OnGameRestart();
    }

}
