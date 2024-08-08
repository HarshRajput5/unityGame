using System.Collections;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate; // Default spawn rate
    // public float spawnRateDecreaseInterval = 1f; // Interval for spawn rate decrease
    // public float spawnRateDecreaseAmount = 0.5f;  // Amount to decrease the spawn rate by
    // public float minSpawnRate = 0.1f; // Minimum spawn rate threshold
    bool gameStarted = false;
    public TextMeshProUGUI scoreText;
    int score = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnCoin", 0.5f, spawnRate);
        // StartCoroutine(DecreaseSpawnRateOverTime());
    }

    private void SpawnCoin()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(coin, spawnPos, Quaternion.identity);
    }

    // IEnumerator DecreaseSpawnRateOverTime()
    // {
    //     while (gameStarted)
    //     {
    //         yield return new WaitForSeconds(spawnRateDecreaseInterval);
    //         spawnRate = Mathf.Max(minSpawnRate, spawnRate - spawnRateDecreaseAmount); // Ensuring spawnRate doesn't go below the minimum threshold
    //         CancelInvoke("SpawnCoin");
    //         InvokeRepeating("SpawnCoin", 0.5f, spawnRate);
    //     }
    // }

    public void IncreaseScore(int x)
    {
        score += x;
        scoreText.text = score.ToString();
    }

    public int FinalScore()
    {
        return score;
    }
}
