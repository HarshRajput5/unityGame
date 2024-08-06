using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject DoubleScore;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool gameStarted = false;

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
        InvokeRepeating("Spawn2X",0.5f,spawnRate);
    }

    private void Spawn2X()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX,maxX);

        Instantiate(DoubleScore, spawnPos, Quaternion.identity);

    }
}
