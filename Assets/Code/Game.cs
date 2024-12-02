using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Game : MonoBehaviour
{
    public static Game i;
    public Ball ball;
    public float radius;
    bool isResetting;
    public int score;
    public TMP_Text scoreText;
    
    void Awake()
    {
        i = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(Vector2.Distance(ball.transform.position, Vector2.zero) > radius && !isResetting)
        {
            ResetScore();
            ball.ResetBall();
        }   
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}
