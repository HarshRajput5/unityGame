using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score(int finalScore)
    {
        score = GetComponent<TextMeshProUGUI>();
        score.text = finalScore.ToString();
        // score+=x;
        // scoreText.text = score.ToString();
    }
}
