using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FlutterUnityIntegration;
// using Firebase.Extensions;
// using Firebase.Firestore;
public class OverGame : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        Debug.Log($"Final score: {score}");
        SendScoreToFlutter(score);
    }

    public void SendScoreToFlutter(int score)
    {
        string scoreMessage = score.ToString();
        UnityMessageManager.Instance.SendMessageToFlutter(scoreMessage);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {
        Application.Quit();
         // If running in the Unity Editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     //         if (Application.platform == RuntimePlatform.Android)
    //     //   {
    //     if (Input.GetKey(KeyCode.Escape))
    //     {
    //         Application.Quit();
    //     }
    //     //   }
    // }
}
