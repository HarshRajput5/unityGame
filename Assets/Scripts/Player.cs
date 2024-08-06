using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    // bool doubleScore;
    public OverGame overGame;
    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 targetPosition = new Vector2(touchPos.x, rb.position.y);
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, 1000));

            // OnCollisionEnter2D();

            // if(touchPos.x < 0)
            // {
            //     rb.AddForce(Vector2.left * moveSpeed);
            // }
            // else
            // {
            //     rb.AddForce(Vector2.right * moveSpeed);
            // }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            // SceneManager.LoadScene(0);
            // SceneManager.LoadScene("GameOver");
            // gameObject
            // Handheld.Vibrate();
            Destroy(gameObject);
            CoinManager coinManager = FindObjectOfType<CoinManager>();
            
            overGame.Setup(coinManager.FinalScore());
            // SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Coin")
        {
            // Access the CoinManager script
            audioManager.PlaySFX(audioManager.coinPick);
            CoinManager coinManager = FindObjectOfType<CoinManager>();
            // Debug.Log($"Double Score: {doubleScore}");
            // if (doubleScore == true)
            // {
            //     float timer = 0f;

            //     while (timer < 5f)
            //     {
            //         // doubleScore = true;
            //         coinManager.IncreaseScore();
            //         timer++;
            //     }
            //     doubleScore = false;
            // }
            // else
            // {
                coinManager.IncreaseScore(1);
            // }
            // coinManager.IncreaseScore(1);

            Debug.Log($"Score {coinManager.scoreText.text}");

            Coin coin = FindObjectOfType<Coin>();
            coin.DestoryMethod();
        }
        if (collision.gameObject.tag == "DoubleScore")
        {
            audioManager.PlaySFX(audioManager.coinPick);
            
            CoinManager coinManager = FindObjectOfType<CoinManager>();
            coinManager.IncreaseScore(5);

            DoubleScore score = FindObjectOfType<DoubleScore>();

            score.DestoryMethod();

            // doubleScore = true;


        }
    }

    // private void OnCollisionEnter2D(Collider2D other)
    // {

    // }

}
