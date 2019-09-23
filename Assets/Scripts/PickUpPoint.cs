using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public int scoreToGive;

    private ScoreManager theScoreManager;

    public AudioSource coinSound;

    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            coinSound.Play();
            theScoreManager.AddExtraPoint(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
