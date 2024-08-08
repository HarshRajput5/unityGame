using System.Collections;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using UnityEngine;

public class ManagerGame1 : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;
    // public GameObject tapText;
    public float spawnRateDecreaseInterval = 1f; // Interval for spawn rate decrease
    public float spawnRateDecreaseAmount = 0.1f;  // Amount to decrease the spawn rate by
    public float minSpawnRate = 0.5f; // Minimum spawn rate threshold

    // public TextMeshProUGUI scoreText;
    // int score = 0;
    public void Setup()
    {
        gameObject.SetActive(true);
        // Debug.Log($"Final score: {score}");
        // SendScoreToFlutter(score);
    }

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
        InvokeRepeating("SpawnBlock",0.5f,spawnRate);
        StartCoroutine(DecreaseSpawnRateOverTime());
    
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX,maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        // score++;

        // scoreText.text = score.ToString();
    }
    IEnumerator DecreaseSpawnRateOverTime()
    {
        while (gameStarted)
        {
            yield return new WaitForSeconds(spawnRateDecreaseInterval);
            spawnRate = Mathf.Max(minSpawnRate, spawnRate - spawnRateDecreaseAmount); // Ensuring spawnRate doesn't go below the minimum threshold
            CancelInvoke("SpawnCoin");
            InvokeRepeating("SpawnCoin", 0.5f, spawnRate);
        }
    }
}
