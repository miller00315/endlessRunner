using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private float scoreCount;
    private float highScoreCount;

    public float pointsPerSeconds;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSeconds * Time.deltaTime;
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High score: "+ Mathf.Round(highScoreCount);

    }

    public void OnGameRestart()
    {
        scoreCount = 0;
        scoreIncreasing = true;
    }

    public void OnPlayerDye()
    {
        scoreIncreasing = false;
    }

    public void AddExtraPoint(int extraPoint)
    {
        scoreCount += extraPoint;
    }

    public void setScoreIncreasing(bool value)
    {
        scoreIncreasing = value;
    }

    public float GetScoreCount(){
        return scoreCount;
    }

    public void HideScores()
    {
        scoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

    public void ShowScores()
    {
        scoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }
}
