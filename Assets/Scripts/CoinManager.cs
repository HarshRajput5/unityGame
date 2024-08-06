using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinManager : MonoBehaviour
{
    
    public GameObject coin;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;
    // public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            // tapText.SetActive(false);
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnCoin",0.5f,spawnRate);
    }

    private void SpawnCoin()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX,maxX);

        Instantiate(coin, spawnPos, Quaternion.identity);

        // score++;

        // scoreText.text = score.ToString();
    }

    public void IncreaseScore(int x)
    {
        score+=x;
        scoreText.text = score.ToString();
        // GameOverScore finalScore = FindObjectOfType<GameOverScore>();
            
        // finalScore.Score(score);
    }
    public int FinalScore(){
        return score;
    }
}
