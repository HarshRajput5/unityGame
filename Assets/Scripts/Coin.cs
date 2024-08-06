using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.tag=="Player")
    //     {
    //         // Access the CoinManager script
    //         CoinManager coinManager = FindObjectOfType<CoinManager>();
    //         coinManager.IncreaseScore();

    //         Debug.Log($"Score {coinManager.scoreText.text}");

    //         // Destroy the coin
    //         Destroy(gameObject);
    //     }
    // }

    public void DestoryMethod(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
